using _0_Framework.Application;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OpretionResult Create(CreateProduct command);
        OpretionResult Edit(EditProduct command);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);

    }
}
