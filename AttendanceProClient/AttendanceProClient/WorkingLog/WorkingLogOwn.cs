using HtmlAgilityPack;
using System.Collections.Generic;

namespace AttendanceProClient.Client
{
    public class WorkingLogOwn : WorkingLog
    {
        public WorkingLogOwn(HtmlDocument doc)
        {
            var personNameNode = doc.DocumentNode.SelectSingleNode("//span[@id='ctl00_ContentMain_PageHeaderUC1_lblEmployeeName']");
            if (personNameNode != null)
            {
                PersonName = personNameNode.InnerText;
            }

            var detailTdNodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_ContentMain_grdMonthlyTotal']//tr[2]/td");
            if (detailTdNodes != null)
            {
                // 所定労働時間
                SetTotalMonthlyNeeds(detailTdNodes[0].InnerText);
                // 勤務時間
                SetTotalMonthlyCurrent(detailTdNodes[1].InnerText);
                // 不就労
                SetTotalMonthlyRemains(detailTdNodes[7].InnerText);
            }

            // 日々の履歴
            Histories = new List<LogItem>();

            var trNodes = doc.DocumentNode.SelectNodes("//div[@id='ctl00_ContentMain_pnlAttendData']//tr");
            // 1行目はヘッダなので、2行目から検索
            for (int i = 1, len = trNodes.Count; i < len; ++i)
            {
                var trNode = trNodes[i];
                var log = new LogItem();

                // 平日かどうか
                var bgColor = trNode.GetAttributeValue("style", "");
                log.IsWeekday = bgColor.Contains("background-color:White;");

                foreach (var tdNode in trNode.ChildNodes)
                {
                    var className = tdNode.GetAttributeValue("class", null);
                    var idName = tdNode.GetAttributeValue("id", null);

                    if (className == "DateWod")
                    {
                        // 日付
                        log.Date = tdNode.InnerText;
                    }
                    else if (className == "AttendDivBtn")
                    {
                        // 「変更」ボタンが押せるかどうか
                        var inputNode = tdNode.FirstChild;
                        log.IsButtonEnabled = (inputNode.GetAttributeValue("disabled", "") != "disabled");
                    }
                    else if (idName != null)
                    {
                        if (idName.EndsWith("_CellState"))
                        {
                            // 承認状況
                            log.IsNotEnteredStatus = (tdNode.InnerText == "未入力");
                        }
                        else if (idName.EndsWith("_celFreeColumn1"))
                        {
                            // 勤務時間
                            log.SetWorkingTime(tdNode.InnerText);
                        }
                        else if (idName.EndsWith("_celFreeColumn2"))
                        {
                            // 標準差
                            log.SetDiff(tdNode.InnerText);
                        }
                    }
                }

                // 入力すべき日に入力しているかどうか
                if (log.IsWeekday && log.IsButtonEnabled && log.IsNotEnteredStatus)
                {
                    log.HasEmptyForm = true;
                    EmptyFormsCount++;
                }

                // 勤務時間の累計
                if (log.HasWorkingTime)
                {
                    // 累計残業時間
                    TotalMonthlyOvertime += log.Overtime;

                    // 最後の勤務日
                    TodayWorkdayHistory = log;
                }

                Histories.Add(log);
            }
        }
    }
}
