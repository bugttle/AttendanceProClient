using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AttendanceProClient.Client
{
    public static class QueryCreator
    {
        static Regex AttendanceExercisedMonthlyDetailsWebResourceUrlRegex = new Regex(@"src=""(/WebResource.axd\?.+?)""", RegexOptions.Multiline);
        static Regex AttendanceExercisedMonthlyDetailsUrlRegex = new Regex(@"'(AttendanceExercisedMonthlyDetails.aspx\?.+?)';", RegexOptions.Multiline);

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

        public static IEnumerable<string> FindTargetSubordinates(string html)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var subordinateNodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_ContentMain_gvResultsShiftType1']//input[@type='submit']");
            if (subordinateNodes != null)
            {
                return subordinateNodes.Select(node => node.GetAttributeValue("name", null));
            }
            return null;
        }

        /// <summary>
        /// トップページを解析し、部下の月時承認ページへのリクエストを作成する。
        /// </summary>
        /// <param name="html"></param>
        /// <param name="target">ex.) ctl00$ContentMain$gvResultsShiftType1$ctl02$DialogDisplayButton1</param>
        /// <returns></returns>
        public static NameValueCollection QueryForApprovalMonthlyPage(string html, string targetSubordinate)
        {
            var ps = new NameValueCollection();

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            ps.Add("__EVENTTARGET", "");
            ps.Add("__EVENTARGUMENT", "");
            ps.Add("__LASTFOCUS", "");
            var viewStateNode = doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']");
            if (viewStateNode != null)
            {
                ps.Add("__VIEWSTATE", viewStateNode.GetAttributeValue("value", ""));
            }
            var viewStateGeneratorNode = doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATEGENERATOR']");
            if (viewStateGeneratorNode != null)
            {
                ps.Add("__VIEWSTATEGENERATOR", viewStateGeneratorNode.GetAttributeValue("value", ""));
            }
            ps.Add("__VIEWSTATEENCRYPTED", "");
            ps.Add("ctl00$Header$ddlSelectedLanguage", "1");

            var yearMonthNode = doc.DocumentNode.SelectSingleNode("//select[@id='ctl00_ContentMain_ddlYearMonth']/option[@selected='selected']");
            if (yearMonthNode != null)
            {
                ps.Add("ctl00$ContentMain$ddlYearMonth", yearMonthNode.GetAttributeValue("value", ""));
            }
            ps.Add("ctl00$ContentMain$ddlShiftType", "");

            var handingDayNode = doc.DocumentNode.SelectSingleNode("//input[@id='ctl00_ContentMain_TxtHandlingDay']");
            if (handingDayNode != null)
            {
                ps.Add("ctl00$ContentMain$TxtHandlingDay", handingDayNode.GetAttributeValue("value", ""));
            }

            ps.Add(targetSubordinate, "詳細");

            var hdnCheckNode = doc.DocumentNode.SelectSingleNode("//input[@id='ctl00_HdnCheck']");
            if (hdnCheckNode != null)
            {
                ps.Add("ctl00$HdnCheck", hdnCheckNode.GetAttributeValue("value", ""));
            }

            return ps;
        }

        public static string UrlForAttendanceExercisedMonthlyDetailsPage(string html)
        {
            /* オリジナルスクリプト部分
             <script type='text/javascript' language='javascript'>
             <!--
               var url = 'AttendanceExercisedMonthlyDetails.aspx?EID=96&YM=2017/03&ST=2&PG=MA&VW=FA';
               var userAgent = window.navigator.userAgent.toLowerCase();
               var ret;
               if (userAgent.indexOf('msie') > -1 || userAgent.indexOf('trident/') > -1) {
                   ret = window.showModalDialog(url+((url.indexOf('?')==-1)?'?r=':'&r=')+parseInt(Math.random()*(new Date()).getMilliseconds()),'','status:no;scroll:yes;resizable=yes;maximize:yes;minimize:yes');
               }else{
                   var idx = url.indexOf('?');
                   idx = (idx==-1)?url.length:idx;
                   var temp = url.slice(0,idx);
                   ret = window.open(url+((url.indexOf('?')==-1)?'?r=':'&r=')+parseInt(Math.random()*(new Date()).getMilliseconds()),temp,'resizable=yes,scrollbars=yes,alwaysRaised=yes');
               }
                __doPostBack('__Page','');
             -->
             */
            // https://attendance.cvi.co.jp/AttendanceExercisedMonthlyDetails.aspx?EID=64&YM=2017/03&ST=2&PG=MA&VW=FA&r=9

            var match = AttendanceExercisedMonthlyDetailsUrlRegex.Match(html);
            if (match.Success && 1 < match.Groups.Count)
            {
                var urlString = match.Groups[1] + "&r=" + DateTime.Now.Millisecond.ToString();
                var uri = new Uri(AttendanceProURLs.Top + "/" + urlString);

                var ps = HttpUtility.ParseQueryString(uri.Query);
                return uri.GetLeftPart(UriPartial.Path) + "?" + ps.ToString();
            }

            return null;
        }
    }
}
