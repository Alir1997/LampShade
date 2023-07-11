using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_FrameWork.Application;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OpretionResult Define(DefineColleagueDiscount command);
        OpretionResult Edit(EditColleagueDiscount command);
        OpretionResult Remove(long id);
        OpretionResult Restore(long id);

        EditColleagueDiscount GetDetails(long id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel);

    }
}
