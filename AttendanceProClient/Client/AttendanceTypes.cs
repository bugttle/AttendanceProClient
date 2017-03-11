using System;

namespace AttendanceProClient
{
    // 出退勤の種類
    public enum AttendanceTypes
    {
        Arrival, // 出社
        Depart, // 退社
    }

    static class AttendanceTypesExtensions
    {
        public static string ToName(this AttendanceTypes type)
        {
            switch (type)
            {
                case AttendanceTypes.Arrival:
                    return Properties.Resources.Arrival;

                case AttendanceTypes.Depart:
                    return Properties.Resources.Depart;

                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
        }
    }
}
