using System;
using System.Collections.Generic;

namespace AttendanceProClient.Log
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

        public bool HasEmptyForm(bool ignoreToday)
        {
            if (ignoreToday)
            {
                // 本日分のみ「未入力」を無視する
                return (0 < EmptyFormsCount - 1);
            }
            else
            {
                return (0 < EmptyFormsCount);
            }
        }

        // 履歴
        public List<LogItem> Histories { get; protected set; }
    }
}
