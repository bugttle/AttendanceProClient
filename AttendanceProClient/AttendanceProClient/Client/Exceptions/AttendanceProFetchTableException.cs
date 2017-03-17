using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client
{
    /// <summary>
    /// 月次勤務表の取得に失敗した場合の Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProFetchTableException : SystemException
    {
        public AttendanceProFetchTableException() : base()
        {
        }

        public AttendanceProFetchTableException(string message) : base(message)
        {
        }

        public AttendanceProFetchTableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProFetchTableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}