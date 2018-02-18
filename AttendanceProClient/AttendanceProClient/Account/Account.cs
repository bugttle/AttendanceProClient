using System;

namespace AttendanceProClient.Account
{
    [Serializable]
    public struct Account
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public string CompanyCode { get; set; }

        public Account(string userId, string password, string companyCode)
        {
            UserId = userId;
            Password = password;
            CompanyCode = companyCode;
        }
    }
}
