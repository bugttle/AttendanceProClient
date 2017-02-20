using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client
{
    /// <summary>
    ///  出退勤処理時の Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProAttendException : SystemException
    {
        public AttendanceProAttendException() : base()
        {
        }

        public AttendanceProAttendException(string message) : base(message)
        {
        }

        public AttendanceProAttendException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProAttendException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
