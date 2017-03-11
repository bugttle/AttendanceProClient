using System.Collections.Specialized;

namespace AttendanceProClient.Client
{
    public static class QueryCreator
    {
        /// <summary>
        /// ログインページを解析し、ログインのクエリを作成する
        /// </summary>
        /// <param name="html"></param>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <param name="companyCode"></param>
        /// <returns></returns>
        public static NameValueCollection QueryForLogOnPage(string html, string userId, string password, string companyCode)
        {
            var ps = new NameValueCollection();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            foreach (var node in doc.DocumentNode.SelectNodes("//input"))
            {
                var typeAttribute = node.GetAttributeValue("type", null);
                var nameAttribute = node.GetAttributeValue("name", null);
                string valueAttribute = null;

                if (typeAttribute == "radio")
                {
                    if (node.GetAttributeValue("checked", null) == "checked")
                    {
                        valueAttribute = node.GetAttributeValue("value", "");
                    }
                }
                else
                {
                    if (nameAttribute == "txtUserID")
                    {
                        valueAttribute = userId;
                    }
                    else if (nameAttribute == "txtPassword")
                    {
                        valueAttribute = password;
                    }
                    else if (nameAttribute == "txtCompanyCode")
                    {
                        valueAttribute = companyCode;
                    }
                    else
                    {
                        valueAttribute = node.GetAttributeValue("value", "");
                    }
                }
                if (nameAttribute != null && valueAttribute != null)
                {
                    ps.Add(nameAttribute, valueAttribute);
                }
            }
            return ps;
        }

        /// <summary>
        /// トップページを解析し、出退勤リクエストを作成する。
        /// </summary>
        /// <param name="html"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static NameValueCollection QueryForAttendanceTableDailyPage(string html, AttendanceTypes type)
        {
            var ps = new NameValueCollection();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            ps.Add("__EVENTTARGET", "");
            ps.Add("__EVENTARGUMENT", "");
            ps.Add("__LASTFOCUS", "");

            foreach (var node in doc.DocumentNode.SelectNodes("//select"))
            {
                var value = node.SelectNodes("//option[@selected]")[0].GetAttributeValue("value", null);
                ps.Add(node.GetAttributeValue("name", ""), value);
            }
            foreach (var node in doc.DocumentNode.SelectNodes("//input"))
            {
                var typeAttribute = node.GetAttributeValue("type", null);
                var nameAttribute = node.GetAttributeValue("name", null);
                string valueAttribute = null;

                if (typeAttribute == "radio")
                {
                    if (node.GetAttributeValue("checked", null) == "checked")
                    {
                        valueAttribute = node.GetAttributeValue("value", "");
                    }
                }
                else
                {
                    if (nameAttribute == "clDT")
                    {
                        valueAttribute = System.DateTime.Now.ToString("yyyy/M/dd HH:mm");
                    }
                    else if (typeAttribute != "submit" && node.GetAttributeValue("disabled", null) != "disabled")
                    {
                        valueAttribute = node.GetAttributeValue("value", "");
                    }
                }
                if (nameAttribute != null && valueAttribute != null)
                {
                    ps.Add(nameAttribute, valueAttribute);
                }
            }

            switch (type)
            {
                case AttendanceTypes.Arrival:
                    // 出社
                    ps.Add("ctl00$ContentMain$btnWebStartTime", "出社");
                    break;

                case AttendanceTypes.Depart:
                    // 退社
                    ps.Add("ctl00$ContentMain$btnWebEndTime", "退社");
                    break;
            }

            return ps;
        }
    }
}
