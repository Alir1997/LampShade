﻿
using AccountManagement.Application.Contracts.Role;
using System.Collections.Generic;
using _0_FrameWork.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long, Role>
    {
        List<RoleViewModel> List();
        EditRole GetDetails(long id);
    }
}
