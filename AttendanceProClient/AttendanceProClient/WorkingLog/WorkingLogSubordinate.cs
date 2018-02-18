using ArmyKnifeDotNet.Text;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace AttendanceProClient.Client
{
    public class WorkingLogSubordinate : WorkingLog
    {
        public WorkingLogSubordinate(HtmlDocument doc)
        {
            // 名前
            var personNameNode = doc.DocumentNode.SelectSingleNode("//span[@id='ctl00_ContentMain_lblName']");
            if (personNameNode != null)
            {
                PersonName = personNameNode.InnerText;
            }

            var detailTdNodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_ContentMain_grdMonthlyTotal']//tr[2]/td");
            if (detailTdNodes != null)
            {
                // 所定労働時間
                TotalMonthlyNeeds = Convert.ToTimeSpan(detailTdNodes[0].InnerText);
                // 勤務時間
                TotalMonthlyCurrent = Convert.ToTimeSpan(detailTdNodes[1].InnerText);
                // 不就労
                TotalMonthlyRemains = Convert.ToTimeSpan(detailTdNodes[7].InnerText);
            }

            // 日々の履歴
            Histories = new List<LogItem>();

            var today = System.DateTime.Now;

            var trNodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_ContentMain_gvResults']//tr");
            // 1行目はヘッダなので、2行目から検索
            for (int i = 1, len = trNodes.Count; i < len; ++i)
            {
                var trNode = trNodes[i];
                var log = new LogItem();

                // 日付
                log.Day = i;

                // 平日かどうか
                var bgColor = trNode.GetAttributeValue("style", "");
                log.IsWeekday = (bgColor.Contains("background-color:White;") || (bgColor.Contains("background-color:#F0F0F0;")));

                var tdNodes = trNode.SelectNodes("./td");

                // 年月日
                log.Date = tdNodes[0].FirstChild.InnerText;

                // 承認状況
                log.HasEmptyForm = (tdNodes[7].InnerText == "未入力");

                // 勤務時間
                log.WorkingHour = Convert.ToTimeSpan(tdNodes[8].InnerText);

                // 標準差
                log.Overtime = Convert.ToTimeSpan(tdNodes[10].InnerText);

                // 勤務時間の累計
                if (today.Day <= i)
                {
                    // 累計残業時間
                    TotalMonthlyOvertime += log.Overtime;
                    if (log.HasEmptyForm)
                    {
                        EmptyFormsCount++;
                    }
                }

                Histories.Add(log);
            }
        }
    }
}
