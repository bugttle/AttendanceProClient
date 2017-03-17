using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client
{
    /// <summary>
    /// ログインに失敗した場合の Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProLoginException : SystemException
    {
        public AttendanceProLoginException() : base()
        {
        }

        public AttendanceProLoginException(string message) : base(message)
        {
        }

        public AttendanceProLoginException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProLoginException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
