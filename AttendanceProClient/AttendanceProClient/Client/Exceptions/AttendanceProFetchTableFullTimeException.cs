using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client
{
    /// <summary>
    /// 月次勤務表の取得に失敗した場合の Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProFetchTableFullTimeException : SystemException
    {
        public AttendanceProFetchTableFullTimeException() : base()
        {
        }

        public AttendanceProFetchTableFullTimeException(string message) : base(message)
        {
        }

        public AttendanceProFetchTableFullTimeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProFetchTableFullTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
