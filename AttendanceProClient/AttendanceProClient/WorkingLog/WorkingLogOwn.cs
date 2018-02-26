using ArmyKnifeDotNet.Text;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace AttendanceProClient.Client
{
    public class WorkingLogOwn : WorkingLog
    {
        // 月時確定のボタンが押せるかどうか
        public bool IsMonthlyCommitButtonEnabled { get; private set; }

        // 最後の勤務日ログ
        public LogItem LastWorkdayLog { get; private set; }

        // 最後の平日
        LogItem lastWeekdayLog;

        public bool IsTodayLastWorkday
        {
            // 月の最終日出社日かどうかを判定
            get { return lastWeekdayLog.IsChangeButtonEnabled; }
        }

        public WorkingLogOwn(HtmlDocument doc)
        {
            // 名前
            var personNameNode = doc.DocumentNode.SelectSingleNode("//span[@id='ctl00_ContentMain_PageHeaderUC1_lblEmployeeName']");
            if (personNameNode != null)
            {
                PersonName = personNameNode.InnerText;
            }

            // 月次確定
            var monthlyCommitButtonNode = doc.DocumentNode.SelectSingleNode("//input[@id='ctl00_ContentMain_MonthlyCommitButton']");
            if (monthlyCommitButtonNode != null)
            {
                IsMonthlyCommitButtonEnabled = (monthlyCommitButtonNode.GetAttributeValue("disabled", "") != "disabled");
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
                        log.IsChangeButtonEnabled = (inputNode.GetAttributeValue("disabled", "") != "disabled");
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
                            log.WorkingHour = Convert.ToTimeSpan(tdNode.InnerText);
                        }
                        else if (idName.EndsWith("_celFreeColumn2"))
                        {
                            // 標準差
                            log.Overtime = Convert.ToTimeSpan(tdNode.InnerText);
                        }
                    }
                }

                // 入力すべき日に入力しているかどうか
                if (log.IsWeekday && log.IsChangeButtonEnabled && isNotEnteredStatus)
                {
                    log.HasEmptyForm = true;
                    EmptyFormsCount++;
                }

                // 勤務時間の累計
                if (hasWorkingTime)
                {
                    // 累計残業時間
                    TotalMonthlyOvertime += log.Overtime;
                    // 働いた最後の日
                    LastWorkdayLog = log;
                }

                if (log.IsWeekday)
                {
                    // 最後の平日を記憶
                    lastWeekdayLog = log;
                }

                Histories.Add(log);
            }
        }
    }
}