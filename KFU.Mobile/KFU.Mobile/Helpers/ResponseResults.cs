 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFU.Mobile.Helpers
{
    public class ResponseResults
    {
        public enum AccountResult
        {
            Saved,
            UserMobileExist,
            UserEmailExist,
            UserNameExist,
            CompanyMobileExist,
            CompanyEmailExist,
            CompanyNameExist,
            NotSaved,
            UserPasswordIncorrect
        }

        public enum LoginUserResult
        {
            Done,
            InActive,
            Failed,
            Bokcked
        }

    }
}
