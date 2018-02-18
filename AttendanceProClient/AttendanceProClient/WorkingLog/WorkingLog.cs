using System;
using System.Collections.Generic;

namespace AttendanceProClient.Client
{
    public class WorkingLog
    {
        // 対象となる人の名前
        public string PersonName { get; protected set; }

        // 所定労働時間
        public TimeSpan TotalMonthlyNeeds { get; protected set; }

        // 勤務時間
        public TimeSpan TotalMonthlyCurrent { get; protected set; }

        // 不就労
        public TimeSpan TotalMonthlyRemains { get; protected set; }

        // 累計残業時間
        public TimeSpan TotalMonthlyOvertime { get; protected set; }

        // 今日までの「未入力」な平日の数
        public int EmptyFormsCount { get; protected set; }

        // 履歴
        public List<LogItem> Histories { get; protected set; }
    }
}
