using _0_Framework.Application;
using _0_FrameWork.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OpretionResult Create(CreateRole command);
        OpretionResult Edit(EditRole command);
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
