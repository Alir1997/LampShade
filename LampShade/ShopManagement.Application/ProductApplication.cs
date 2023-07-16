using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public OpretionResult Create(CreateProduct command)
        {

        

            var operation = new OpretionResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var product = new Product
                (
                    
              name: command.Name,
              code:  command.Code,
              picture:   command.Picture,
              shortDescription:   command.ShortDescription,
              description:  command.Description,
              pictureAlt:  command.PictureAlt,
              pictureTitle:  command.PictureTitle,
              categoryId:  command.CategoryId,
              slug:  command.Slug,
              keywords:  command.Keywords,
              metaDescription: command.MetaDescription
              
             );



            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OpretionResult Edit(EditProduct command)
        {
            var operation = new OpretionResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
            {
                return operation.Failed(ApplicationMessages.RecordNotFound);
            }
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();

            product.Edit(command.Name, command.Code, 
                command.ShortDescription, command.Description, command.Picture,
                command.PictureAlt, command.PictureTitle, command.CategoryId, slug,
                command.Keywords, command.MetaDescription);

            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
