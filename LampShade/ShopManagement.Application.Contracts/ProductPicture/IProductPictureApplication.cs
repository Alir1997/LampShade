using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OpretionResult Create(CreateProductPicture command);
        OpretionResult Edit(EditProductPicture command);
        OpretionResult Remove(long Id);
        OpretionResult Restore(long Id);
        EditProductPicture GetDetails(long Id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
