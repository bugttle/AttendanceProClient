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
        public AttendanceTypes AttendanceType { get; private set; }

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

        public AttendanceProAttendException(AttendanceTypes type)
        {
            AttendanceType = type;
        }
    }
}