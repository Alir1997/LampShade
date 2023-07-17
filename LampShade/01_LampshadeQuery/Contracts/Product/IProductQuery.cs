
namespace _01_LampshadeQuery.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetDetails(string slug);
        List<ProductQueryModel> GetLattestArrivals();
        List<ProductQueryModel> Search(string value);
    }
}
