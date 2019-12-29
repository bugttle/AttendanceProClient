using DotNetCommonLibrary.Text;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace AttendanceProClient.Log
{
    public class WorkingLogSubordinate : WorkingLog
    {
        public WorkingLogSubordinate(HtmlDocument doc, int today)
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
                TotalMonthlyNeeds = Converter.ToTimeSpan(detailTdNodes[0].InnerText);
                // 勤務時間
                TotalMonthlyCurrent = Converter.ToTimeSpan(detailTdNodes[1].InnerText);
                // 不就労
                TotalMonthlyRemains = Converter.ToTimeSpan(detailTdNodes[7].InnerText);
            }

            // 日々の履歴
            Histories = new List<LogItem>();

            var trNodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_ContentMain_gvResults']//tr");
            // 1行目はヘッダなので、2行目から検索
            for (int i = 1, len = trNodes.Count; i < len; ++i)
            {
                var trNode = trNodes[i];
                var log = new LogItem();

                // 日付
                log.Day = i;

                // 過去の日付かどうか
                var isPastDay = log.Day < today;

                // 平日かどうか
                var bgColor = trNode.GetAttributeValue("style", "");
                log.IsWeekday = (bgColor.Contains("background-color:White;") || (bgColor.Contains("background-color:#F0F0F0;")));

                var tdNodes = trNode.SelectNodes("./td");

                // 年月日
                log.Date = tdNodes[0].FirstChild.InnerText;

                // 変更
                var inputNode = tdNodes[6].FirstChild;
                log.IsChangeButtonEnabled = (inputNode != null && inputNode.GetAttributeValue("disabled", "") != "disabled");

                // 勤務時間
                var workingHour = tdNodes[8].InnerText;
                log.WorkingHour = Converter.ToTimeSpan(workingHour);

                // 昨日までで、入力すべき日に入力しているかどうか
                if (isPastDay && log.IsWeekday && string.IsNullOrEmpty(workingHour))
                {
                    log.HasEmptyForm = true;
                    EmptyFormsCount++;
                }

                // 標準差
                log.Overtime = Converter.ToTimeSpan(tdNodes[10].InnerText);

                // 勤務時間の累計
                if (isPastDay && log.IsWeekday)
                {
                    // 累計残業時間
                    TotalMonthlyOvertime += log.Overtime;
                }

                Histories.Add(log);
            }
        }
    }
}