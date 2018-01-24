using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client
{
    /// <summary>
    /// 権限が不足している場合の Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProPermissionException : SystemException
    {
        public AttendanceProPermissionException() : base()
        {
        }

        public AttendanceProPermissionException(string message) : base(message)
        {
        }

        public AttendanceProPermissionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProPermissionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
