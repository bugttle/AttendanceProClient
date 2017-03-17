using System;
using AttendanceProClient.Utilities;

namespace AttendanceProClient.Client
{
    public struct WorkingLogItem
    {
        // 日付
        public string Date { get; set; }

        // 平日かどうか
        public bool IsWeekday { get; set; }

        // 勤務時間があるか
        public bool HasWorkingTime { get; set; }

        // 勤務時間
        public TimeSpan WokingHour { get; private set; }

        // 標準差
        public TimeSpan WorkingDifference { get; private set; }

        // 「変更」ボタンが押せるか
        public bool IsButtonEnabled { get; set; }

        // 「未入力」な項目があるかどうか
        public bool HasEmptyForm { get; set; }

        // ステータスが「未入力」かどうか
        public bool IsNotEnteredStatus { get; set; }

        public void SetWorkingTime(string time)
        {
            if (!string.IsNullOrEmpty(time))
            {
                HasWorkingTime = true;
                WokingHour = TimeUtility.ToTimeSpan(time);
            }
        }

        public void SetDiff(string time)
        {
            if (!string.IsNullOrEmpty(time))
            {
                WorkingDifference = TimeUtility.ToTimeSpan(time);
            }
        }
    }
}
