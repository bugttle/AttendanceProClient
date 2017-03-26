using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client
{
    /// <summary>
    /// 月次勤務表の取得に失敗した場合の Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProFetchAttendanceExercisedMonthlyDetailsException : SystemException
    {
        public AttendanceProFetchAttendanceExercisedMonthlyDetailsException() : base()
        {
        }

        public AttendanceProFetchAttendanceExercisedMonthlyDetailsException(string message) : base(message)
        {
        }

        public AttendanceProFetchAttendanceExercisedMonthlyDetailsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProFetchAttendanceExercisedMonthlyDetailsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
