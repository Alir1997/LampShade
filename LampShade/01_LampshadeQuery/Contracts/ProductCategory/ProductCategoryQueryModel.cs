﻿
using _01_LampshadeQuery.Contracts.Product;

namespace _01_LampshadeQuery.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public long Id { get; set; }

        public List<ProductQueryModel> Products { get; set; }
    }
}
