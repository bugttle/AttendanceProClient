using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using AttendanceProClient.Utilities;

namespace AttendanceProClient.Client
{
    public class WorkingLogOwn : WorkingLog
    {
        // 最後の勤務日ログ
        public LogItem LastWorkdayLog { get; private set; }

        LogItem LastWeekdayLog;
        public bool IsTodayLastWorkday { get; private set; }

        public WorkingLogOwn(HtmlDocument doc)
        {
            var today = DateTime.Now;

            var personNameNode = doc.DocumentNode.SelectSingleNode("//span[@id='ctl00_ContentMain_PageHeaderUC1_lblEmployeeName']");
            if (personNameNode != null)
            {
                PersonName = personNameNode.InnerText;
            }

            var detailTdNodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_ContentMain_grdMonthlyTotal']//tr[2]/td");
            if (detailTdNodes != null)
            {
                // 所定労働時間
                TotalMonthlyNeeds = TimeUtility.ToTimeSpan(detailTdNodes[0].InnerText);
                // 勤務時間
                TotalMonthlyCurrent = TimeUtility.ToTimeSpan(detailTdNodes[1].InnerText);
                // 不就労
                TotalMonthlyRemains = TimeUtility.ToTimeSpan(detailTdNodes[7].InnerText);
            }

            // 日々の履歴
            Histories = new List<LogItem>();

            var trNodes = doc.DocumentNode.SelectNodes("//div[@id='ctl00_ContentMain_pnlAttendData']//tr");
            // 1行目はヘッダなので、2行目から検索
            for (int i = 1, len = trNodes.Count; i < len; ++i)
            {
                var trNode = trNodes[i];
                var log = new LogItem();

                // 日付
                log.Day = i;

                // 平日かどうか
                var bgColor = trNode.GetAttributeValue("style", "");
                log.IsWeekday = bgColor.Contains("background-color:White;");

                // ステータスが「未入力」かどうか
                var isNotEnteredStatus = false;
                var hasWorkingTime = false;
                var isButtonEnabled = false;

                foreach (var tdNode in trNode.ChildNodes)
                {
                    var className = tdNode.GetAttributeValue("class", null);
                    var idName = tdNode.GetAttributeValue("id", null);

                    if (className == "DateWod")
                    {
                        // 年月日
                        log.Date = tdNode.InnerText;
                    }
                    else if (className == "AttendDivBtn")
                    {
                        // 「変更」ボタンが押せるかどうか
                        var inputNode = tdNode.FirstChild;
                        isButtonEnabled = (inputNode.GetAttributeValue("disabled", "") != "disabled");
                    }
                    else if (idName != null)
                    {
                        if (idName.EndsWith("_CellState"))
                        {
                            // 承認状況
                            isNotEnteredStatus = (tdNode.InnerText == "未入力");
                        }
                        else if (idName.EndsWith("_celFreeColumn1"))
                        {
                            // 勤務時間
                            hasWorkingTime = true;
                            log.WorkingHour = TimeUtility.ToTimeSpan(tdNode.InnerText);
                        }
                        else if (idName.EndsWith("_celFreeColumn2"))
                        {
                            // 標準差
                            log.Overtime = TimeUtility.ToTimeSpan(tdNode.InnerText);
                        }
                    }
                }

                // 入力すべき日に入力しているかどうか
                if (log.IsWeekday && isButtonEnabled && isNotEnteredStatus)
                {
                    log.HasEmptyForm = true;
                    EmptyFormsCount++;
                }

                // 勤務時間の累計
                if (hasWorkingTime)
                {
                    // 累計残業時間
                    TotalMonthlyOvertime += log.Overtime;
                    // 最後の勤務日
                    LastWorkdayLog = log;
                }

                if (log.IsWeekday)
                {
                    // 最後の平日を記憶
                    LastWeekdayLog = log;
                }

                Histories.Add(log);
            }

            // 月の最終日かどうかを判定
            if (LastWeekdayLog.Day < today.Day)
            {
                IsTodayLastWorkday = true;
            }
        }
    }
}
