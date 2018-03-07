using System;

namespace AttendanceProClient
{
    public class TimeKeeper
    {
        static TimeKeeper mInstance;

        public static TimeKeeper Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new TimeKeeper();
                }
                return mInstance;
            }
        }

        public bool IsFinished { get; set; }

        public bool UpdateTime()
        {
            if (IsInAttendTime())
            {
                return !IsFinished;
            }
            else
            {
                // 時間外ならフラグをリセット
                IsFinished = false;
                return IsFinished;
            }
        }

        bool IsInAttendTime()
        {
            var now = DateTime.Now;
            // 7時から12時まで
            return (7 <= now.Hour && now.Hour <= 12);
        }
    }
}
