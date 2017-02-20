namespace AttendanceProClient.Client
{
    public static class ResponseValidator
    {
        // ログインが正常に完了しているかのチェック
        public static void ValidateLoggedIn(string html)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            // ログインに失敗していた場合に表示されるメッセージの確認
            var node = doc.DocumentNode.SelectSingleNode("//span[@id='lblMessage']");
            if (node != null)
            {
                throw new AttendanceProLoginException(node.InnerText);
            }

            // パスワードの期限が切れているかのチェック
            node = doc.DocumentNode.SelectSingleNode("//input[@id='ctl00_ContentMain_btnChangePassword']");
            if (node != null)
            {
                throw new AttendanceProPasswordExpiredException();
            }

            // ログイン成功していれば、 id="aspnetForm" のフォームがある
            node = doc.DocumentNode.SelectSingleNode("//form[@id='aspnetForm']");
            if (node != null)
            {
                return; // ログイン成功している
            }

            // その他のエラー
            throw new AttendanceProLoginException();
        }

        public static void ValidateAttended(string html, AttendanceTypes type)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            // 出勤に成功していれば、 id="ctl00_ContentMain_txtStartTime" がある
            // 退勤に成功していれば、 id="ctl00_ContentMain_txtEndTime" がある
            var id = (type == AttendanceTypes.In) ? "ctl00_ContentMain_txtStartTime" : "ctl00_ContentMain_txtEndTime";
            var node = doc.DocumentNode.SelectSingleNode("//input[@id='" + id + "']");
            if (node != null)
            {
                // 時刻が入力されているかをチェック
                var valueAttribute = node.GetAttributeValue("value", null);
                if (valueAttribute != null)
                {
                    return; // 出退勤に成功している
                }
            }

            throw new AttendanceProAttendException();
        }
    }
}
