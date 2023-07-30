using Bitirme_Business.Interfaces;
using Bitirme_Data.Repository.Interfaces;
using Bitirme_Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bitirme_Business.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IGenericRepository<Product> _productRepo;
        public ProductBusiness(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }
        public void AddProduct(Product product)
        {
            _productRepo.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            var product = _productRepo.GetById(productId);
            _productRepo.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAll().ToList();
        }

        public Product GetProductWithCategory(int productId)
        {
            var product = _productRepo.GetQuery()
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductID == productId);

            if(product == null)
            {
                throw new Exception($"{product.Name} bulunamadı");
            }

            return product;
        }

        public void UpdateProduct(Product product)
        {
            _productRepo.Update(product);
        }
    }
}
