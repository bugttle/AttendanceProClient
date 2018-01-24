using System;
using System.Runtime.Serialization;

namespace AttendanceProClient.Client
{
    /// <summary>
    ///     Exception
    /// </summary>
    [SerializableAttribute]
    class AttendanceProFetchApprovalMonthlyException : SystemException
    {
        public AttendanceProFetchApprovalMonthlyException() : base()
        {
        }

        public AttendanceProFetchApprovalMonthlyException(string message) : base(message)
        {
        }

        public AttendanceProFetchApprovalMonthlyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AttendanceProFetchApprovalMonthlyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
