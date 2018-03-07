using System;

namespace AttendanceProClient.Log
{
    public struct LogItem
    {
        // 年月日
        public string Date { get; set; }

        // 日付
        public int Day { get; set; }

        // 平日かどうか
        public bool IsWeekday { get; set; }

        // 「未入力」な項目があるかどうか
        public bool HasEmptyForm { get; set; }

        // 「変更」ボタンがあるかどうか
        public bool HasChangeButton { get; set; }

        // 「変更」ボタンが押せるかどうか
        public bool IsChangeButtonEnabled { get; set; }

        // 勤務時間
        public TimeSpan WorkingHour { get; set; }

        // 標準差
        public TimeSpan Overtime { get; set; }
    }
}
