using ArmyKnifeDotNet.IO.Serializer;

namespace AttendanceProClient.Account
{
    public class AccountManager
    {
        public Account Account { get; private set; }

        static AccountManager mInstance = null;

        public static AccountManager Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new AccountManager();
                }
                return mInstance;
            }
        }

        AccountManager()
        {
        }

        /// <summary>
        /// アカウント情報の読み出し
        /// </summary>
        /// <returns></returns>
        public Account Load()
        {
            try
            {
                var serializer = new EncryptionSerializer();
                Account = serializer.DeserializeFromFile<Account>();
            }
            catch
            {
                Account = new Account("", "", "");
            }
            return Account;
        }

        /// <summary>
        /// アカウント情報の保存
        /// </summary>
        public void Save()
        {
            var serializer = new EncryptionSerializer();
            serializer.SerializeToFile<Account>(Account);
        }

        public void SetUserId(string userId)
        {
            Account = new Account(userId, Account.Password, Account.CompanyCode);
        }

        public void SetPassword(string password)
        {
            Account = new Account(Account.UserId, password, Account.CompanyCode);
        }

        /// <summary>
        /// アカウント情報が正しいかどうかを判定
        /// </summary>
        /// <returns></returns>
        public bool IsValidAccount()
        {
            return Account.UserId != null && 0 < Account.UserId.Length &&
                Account.Password != null && 0 < Account.Password.Length &&
                Account.CompanyCode != null && 0 < Account.CompanyCode.Length;
        }
    }
}
