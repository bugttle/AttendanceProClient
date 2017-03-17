using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace AttendanceProClient.Client
{
    public class WorkingTimeTable
    {
        // 累計残業時間
        public TimeSpan TotalWorkingDifference { get; private set; }

        // 今日までの「未入力」な平日の数
        public int EmptyFormsCount { get; private set; }

        // 履歴
        public List<WorkingLogItem> Histories { get; private set; }

        // 本日の作業ログ
        public WorkingLogItem TodayWorkdayHistory { get; private set; }

        public WorkingTimeTable(HtmlDocument doc)
        {
            Histories = new List<WorkingLogItem>();

            foreach (var trNode in doc.DocumentNode.SelectNodes("//div[@id='ctl00_ContentMain_pnlAttendData']/table/tbody/tr"))
            {
                var timeHistory = new WorkingLogItem();

                // 平日かどうか
                var bgColor = trNode.GetAttributeValue("bgcolor", "");
                timeHistory.IsWeekday = bgColor.Contains("White");

                foreach (var tdNode in trNode.ChildNodes)
                {
                    var className = tdNode.GetAttributeValue("class", null);
                    var idName = tdNode.GetAttributeValue("id", null);

                    if (className == "DateWod")
                    {
                        // 日付
                        timeHistory.Date = tdNode.InnerText;
                    }
                    else if (className == "AttendDivBtn")
                    {
                        // 「変更」ボタンが押せるかどうか
                        var inputNode = tdNode.FirstChild;
                        timeHistory.IsButtonEnabled = (inputNode.GetAttributeValue("disabled", "") != "disabled");
                    }
                    else if (idName != null)
                    {
                        if (idName.EndsWith("_CellState"))
                        {
                            // 承認状況
                            timeHistory.IsNotEnteredStatus = (tdNode.InnerText == "未入力");
                        }
                        else if (idName.EndsWith("_celFreeColumn1"))
                        {
                            // 勤務時間
                            timeHistory.SetWorkingTime(tdNode.InnerText);
                        }
                        else if (idName.EndsWith("_celFreeColumn2"))
                        {
                            // 標準差
                            timeHistory.SetDiff(tdNode.InnerText);
                        }
                    }
                }

                // 入力すべき日に入力しているかどうか
                if (timeHistory.IsWeekday && timeHistory.IsButtonEnabled && timeHistory.IsNotEnteredStatus)
                {
                    timeHistory.HasEmptyForm = true;
                    EmptyFormsCount++;
                }

                // 勤務時間の累計
                if (timeHistory.HasWorkingTime)
                {
                    // 累計残業時間
                    TotalWorkingDifference += timeHistory.WorkingDifference;

                    // 最後の勤務日
                    TodayWorkdayHistory = timeHistory;
                }

                Histories.Add(timeHistory);
            }
        }
    }
}
