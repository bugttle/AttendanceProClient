using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceProClient.Client
{
    // Disposeを実装しないと、以下のWarningが出るため、実装している
    // Warning CA1001  Implement IDisposable on 'AttendanceProClient' because it creates members of the following IDisposable types: 'CookieAwareWebClient'.
    class AttendanceProClient : IDisposable
    {
        CookieAwareWebClient wc = new CookieAwareWebClient()
        {
            Encoding = Encoding.UTF8
        };

        static AttendanceProClient mInstance = null;

        public static AttendanceProClient Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new AttendanceProClient();
                }
                return mInstance;
            }
        }

        AttendanceProClient()
        {
        }

        public void Dispose()
        {
            wc.Dispose();
        }

        // ログイン
        async Task<string> LogOn(string userId, string password, string companyCode)
        {
            return await Task.Run(() =>
            {
                // トップページの取得
                var html = wc.Get(AttendanceProUrls.LogOnURL);

                // ログイン実行
                var query = QueryCreator.QueryForLogOnPage(html, userId, password, companyCode);
                html = wc.Post(AttendanceProUrls.LogOnURL, query);

                // ログインが正常に完了しているかのチェック
                ResponseValidator.ValidateLoggedIn(html);

                return html;
            });
        }

        async Task<WorkingLogOwn> Attend(string userId, string password, string companyCode, AttendanceTypes type)
        {
            // ログイン後のページ
            var html = await LogOn(userId, password, companyCode);

            await Task.Run(() =>
            {
                // 既に出退勤済かどうか
                ResponseValidator.ValidateAlreadyAttended(html, type);

                // 出退勤実行
                var query = QueryCreator.QueryForAttendanceTableDailyPage(html, type);
                html = wc.Post(AttendanceProUrls.AttendanceTableDailyURL, query);

                // 出退勤が正常に完了しているかのチェック
                ResponseValidator.ValidateAttended(html, type);
            });

            // 月次勤務表の情報を取得
            return await FetchOwnWorkingLog(userId, password, companyCode, withLogOn: false);
        }

        async Task<WorkingLogOwn> FetchOwnWorkingLog(string userId, string password, string companyCode, bool withLogOn)
        {
            var html = "";

            if (withLogOn)
            {
                // ログオン処理
                html = await LogOn(userId, password, companyCode);
            }

            return await Task.Run(() =>
            {
                // 月次勤務表から情報を取得する
                html = wc.Get(AttendanceProUrls.AttendanceTableFullTime);

                // 月次勤務表が取得できているかのチェック
                var doc = ResponseValidator.ValidateFetchedTableFullTime(html);

                return new WorkingLogOwn(doc);
            });
        }

        async Task<WorkingLogSubordinate> FetchSubordinateWorkingLog(string html, string targetSubordinate)
        {
            return await Task.Run(() =>
            {
                // まずは ApprovalMonthlyへアクセスしてURLを取得する
                var query = QueryCreator.QueryForApprovalMonthlyPage(html, targetSubordinate);
                html = wc.Post(AttendanceProUrls.ApprovalMonthly, query);

                // AttendanceExercisedMonthlyDetails へのアクセス
                var url = QueryCreator.UrlForAttendanceExercisedMonthlyDetailsPage(html);
                html = wc.Get(url);
                var doc = ResponseValidator.ValidateFetchedAttendanceExercisedMonthlyDetails(html);

                return new WorkingLogSubordinate(doc);
            });
        }

        async Task<List<WorkingLogSubordinate>> FetchSubordinateWorkingLogs(string html)
        {
            // 部下全員分の情報を取得
            var targetSubordinates = QueryCreator.FindTargetSubordinates(html);
            if (targetSubordinates != null)
            {
                var subordinateLogs = new List<WorkingLogSubordinate>();
                foreach (var targetSubordinate in targetSubordinates)
                {
                    /* AttendanceExercisedMonthlyDetails へのアクセス */
                    var log = await FetchSubordinateWorkingLog(html, targetSubordinate);
                    subordinateLogs.Add(log);

                    var random = new Random();
                    await Task.Delay(500 + random.Next(500));
                }
                return subordinateLogs;
            }

            return null;
        }

        async Task<List<WorkingLogSubordinate>> FetchSubordinateWorkingLogs(string userId, string password, string companyCode)
        {
            var html = "";

            // ログオン処理
            html = await LogOn(userId, password, companyCode);

            return await Task.Run(() =>
            {
                // ApprovalMonthlyへアクセス
                html = wc.Get(AttendanceProUrls.ApprovalMonthly);
                ResponseValidator.ValidateFetchedApprovalMonthly(html);

                return FetchSubordinateWorkingLogs(html);
            });
        }

        /// <summary>
        /// ログインができるかのチェック
        /// </summary>
        /// <param name="account"></param>
        public async Task ChceckLogOn(Account.Account account)
        {
            await LogOn(account.UserId, account.Password, account.CompanyCode);
        }

        /// <summary>
        /// 出社 or 退社の実行
        /// </summary>
        /// <param name="account"></param>
        /// <param name="type"></param>
        public async Task<WorkingLogOwn> Attend(Account.Account account, AttendanceTypes type)
        {
            return await Attend(account.UserId, account.Password, account.CompanyCode, type);
        }

        /// <summary>
        /// 月次勤務表から情報を取得する
        /// </summary>
        /// <param name="account"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<WorkingLogOwn> FetchOwnWorkingLog(Account.Account account)
        {
            return await FetchOwnWorkingLog(account.UserId, account.Password, account.CompanyCode, withLogOn: true);
        }

        /// <summary>
        /// 月時承認から部下の勤務情報を取得する
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public async Task<List<WorkingLogSubordinate>> FetchSubordinateWorkingLogs(Account.Account account)
        {
            return await FetchSubordinateWorkingLogs(account.UserId, account.Password, account.CompanyCode);
        }
    }
}
