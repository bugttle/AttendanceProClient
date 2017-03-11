using System;
using System.Threading.Tasks;

namespace AttendanceProClient.Client
{
    // Disposeを実装しないと、以下のWarningが出るため、実装している
    // Warning CA1001  Implement IDisposable on 'AttendanceProClient' because it creates members of the following IDisposable types: 'CookieAwareWebClient'.
    class AttendanceProClient : IDisposable
    {
        CookieAwareWebClient wc = new CookieAwareWebClient();

        public AttendanceProClient()
        {
            wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
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

        async Task Attend(string userId, string password, string companyCode, AttendanceTypes type)
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
        public async Task Attend(Account.Account account, AttendanceTypes type)
        {
            await Attend(account.UserId, account.Password, account.CompanyCode, type);
        }
    }
}
