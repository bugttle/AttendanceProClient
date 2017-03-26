using System;
using System.Collections.Generic;
using AttendanceProClient.Utilities;

namespace AttendanceProClient.Client
{
    public class WorkingLog
    {
        // 対象となる人の名前
        public string PersonName { get; protected set; }

        // 所定労働時間
        public TimeSpan TotalMonthlyNeeds { get; private set; }

        // 勤務時間
        public TimeSpan TotalMonthlyCurrent { get; private set; }

        // 不就労
        public TimeSpan TotalMonthlyRemains { get; private set; }

        // 累計残業時間
        public TimeSpan TotalMonthlyOvertime { get; protected set; }

        // 今日までの「未入力」な平日の数
        public int EmptyFormsCount { get; protected set; }

        // 履歴
        public List<LogItem> Histories { get; protected set; }

        // 本日の作業ログ
        public LogItem TodayWorkdayHistory { get; protected set; }

        public void SetTotalMonthlyNeeds(string time)
        {
            if (!string.IsNullOrEmpty(time))
            {
                TotalMonthlyNeeds = TimeUtility.ToTimeSpan(time);
            }
        }

        public void SetTotalMonthlyCurrent(string time)
        {
            if (!string.IsNullOrEmpty(time))
            {
                TotalMonthlyCurrent = TimeUtility.ToTimeSpan(time);
            }
        }

        public void SetTotalMonthlyRemains(string time)
        {
            if (!string.IsNullOrEmpty(time))
            {
                TotalMonthlyRemains = TimeUtility.ToTimeSpan(time);
            }
        }
    }
}
