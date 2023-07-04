using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OpretionResult Create(CreateProductCategory command);
        OpretionResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id); 
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

        List<ProductCategoryViewModel> GetProductCategories();


    }
}
