
using AccountManagement.Application.Contracts.Account;
using _0_FrameWork.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        Account GetBy(string username);
        EditAccount GetDetails(long id);
        List<AccountViewModel> GetAccounts();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
    }
}
