using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client
{
    /// <summary>
    ///  出退勤処理時の Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProAlreadyAttendException : SystemException
    {
        public AttendanceTypes AttendanceType { get; private set; }

        public AttendanceProAlreadyAttendException() : base()
        {
        }

        public AttendanceProAlreadyAttendException(string message) : base(message)
        {
        }

        public AttendanceProAlreadyAttendException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProAlreadyAttendException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public AttendanceProAlreadyAttendException(AttendanceTypes type)
        {
            AttendanceType = type;
        }
    }
}