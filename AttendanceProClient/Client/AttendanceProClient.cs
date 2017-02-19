using System;

namespace AttendanceProClient.Client
{
    // Disposeを実装しないと、以下のWarningが出るため、実装している
    // Warning CA1001  Implement IDisposable on 'AttendanceProClient' because it creates members of the following IDisposable types: 'CookieAwareWebClient'.	AttendanceProClient C:\Users\Ryo\Dropbox\Projects\Mine\AttendanceProClient\Client\Windows\AttendanceProClient\Client\AttendanceProClient.cs	7	Active
    class AttendanceProClient : IDisposable
    {
        const string BaseURL = "https://attendance.cvi.co.jp";
        const string LogOnURL = BaseURL + "/LogOn.aspx";
        const string AttendanceTableDailyURL = BaseURL + "/AttendanceTableDaily.aspx";

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
        string LogOn(string userId, string password, string companyCode)
        {
            // トップページの取得
            var html = wc.Get(LogOnURL);

            // ログイン実行
            var query = QueryCreator.QueryForLogOnPage(html, userId, password, companyCode);
            html = wc.Post(LogOnURL, query);

            // ログインが正常に完了しているかのチェック
            ValidateLoggedIn(html);

            return html;
        }

        // ログインが正常に完了しているかのチェック
        void ValidateLoggedIn(string html)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            // ログイン成功していれば、 id="aspnetForm" のフォームがある
            var node = doc.DocumentNode.SelectSingleNode("//form[@id='aspnetForm']");
            if (node != null)
            {
                // ログイン成功している
                return;
            }
            // ログインに失敗していた場合に表示されるメッセージの確認
            node = doc.DocumentNode.SelectSingleNode("//span[@id='lblMessage']");
            if (node != null)
            {
                throw new AttendanceProLoginException(node.InnerText);
            }

            // パスワードの期限が切れているかのチェック
            //if (node != null)
            //{
            //    throw new AttendanceProPasswordExpiredException();
            //}

            throw new AttendanceProLoginException();
        }

        /// <summary>
        /// 出社 or 退社の実行
        /// </summary>
        /// <param name="account"></param>
        /// <param name="type"></param>
        public void DoAttendance(Account account, AttendanceTypes type)
        {
            var html = LogOn(account.UserId, account.Password, account.CompanyCode);
            var query = QueryCreator.QueryForAttendanceTableDailyPage(html, type);
            wc.Post(AttendanceTableDailyURL, query);
        }
    }
}
