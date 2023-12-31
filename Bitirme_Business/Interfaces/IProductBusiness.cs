﻿using Bitirme_Model.Entities;
using X.PagedList;

namespace Bitirme_Business.Interfaces
{
    public interface IProductBusiness
    {
        Product GetProductWithCategory(int productId);
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        bool ProductExists(string productName);
    }
}
