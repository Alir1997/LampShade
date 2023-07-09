using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OpretionResult Create(CreateSlide command);
        OpretionResult Edit(EditSlide command);
        OpretionResult Remove(long id);
        OpretionResult Restore(long id);
        EditSlide GetDetails(long id);

        List<SlideViewModel> GetList();
    }
}
