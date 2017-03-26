using System;
using System.Text.RegularExpressions;

namespace AttendanceProClient.Utilities
{
    public class TimeUtility
    {
        static Regex TimeRegex = new Regex(@"(-?)(\d+)h:(\d+)m", RegexOptions.IgnoreCase);

        public static TimeSpan ToTimeSpan(string str)
        {
            var match = TimeRegex.Match(str);
            if (match.Success && 2 < match.Groups.Count)
            {
                int coefficient = 1; // 正か負か
                string hourString = null;
                string minString = null;

                // マイナス時間かどうか
                coefficient = (match.Groups[1].Value == "") ? 1 : -1;
                hourString = match.Groups[2].Value;
                minString = match.Groups[3].Value;

                int hour = 0;
                int min = 0;
                if (int.TryParse(hourString, out hour) &&
                    int.TryParse(minString, out min))
                {
                    return new TimeSpan(hour * coefficient, min * coefficient, 0);
                }
            }

            return new TimeSpan();
        }
    }
}