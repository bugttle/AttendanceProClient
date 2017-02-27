using System;

namespace AttendanceProClient
{
    // 出退勤の種類
    public enum AttendanceTypes
    {
        In, // 出社
        Out, // 退社
    }

    static class AttendanceTypesExtensions
    {
        public static string ToName(this AttendanceTypes type)
        {
            switch (type)
            {
                case AttendanceTypes.In:
                    return "出社";

                case AttendanceTypes.Out:
                    return "退社";

                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
        }
    }
}
