using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client.Exceptions
{
    /// <summary>
    /// パスワードの期限が切れている場合の Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProPasswordExpiredException : SystemException
    {
        public AttendanceProPasswordExpiredException() : base()
        {
        }

        public AttendanceProPasswordExpiredException(string message) : base(message)
        {
        }

        public AttendanceProPasswordExpiredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProPasswordExpiredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
