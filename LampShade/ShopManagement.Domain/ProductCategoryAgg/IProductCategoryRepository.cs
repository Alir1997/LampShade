using System.Linq.Expressions;
using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long, ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        string GetSlugById(long id);
        List<ProductCategoryViewModel> GetProductCategories();
    }
}
