using _0_Framework.Application;
using System.Collections.Generic;
using _0_FrameWork.Application;

namespace AccountManagement.Application.Contracts.Account
{
    public interface IAccountApplication
    {
        AccountViewModel GetAccountBy(long id);
        OpretionResult Register(RegisterAccount command);
        OpretionResult Edit(EditAccount command);
        OpretionResult ChangePassword(ChangePassword command);
        OpretionResult Login(Login command);
        EditAccount GetDetails(long id);
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        void Logout();
        List<AccountViewModel> GetAccounts();
    }
}
