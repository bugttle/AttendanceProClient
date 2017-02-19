using System;

namespace AttendanceProClient.Preference
{
    [Serializable]
    public class Account
    {
        public string UserId;
        public string Password;
        public string CompanyCode;

        public Account(string userId = "", string password = "", string companyCode = "")
        {
            UserId = userId;
            Password = password;
            CompanyCode = companyCode;
        }
    }
}
