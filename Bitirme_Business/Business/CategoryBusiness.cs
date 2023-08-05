using Bitirme_Business.Interfaces;
using Bitirme_Data.Repository.Interfaces;
using Bitirme_Model.Entities;

namespace Bitirme_Business.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly IGenericRepository<Category> _categoryRepo;

        public CategoryBusiness(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public void AddCategory(Category category)
        {
            _categoryRepo.Add(category);
        }

        public bool CategoryExists(string categoryName)
        {
            return _categoryRepo.GetAll().Any(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _categoryRepo.GetById(categoryId);
            if (category == null)
            {
                throw new Exception($"{categoryId} bu id'ye sahip kategori bulunamadı");
            }

            _categoryRepo.Delete(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAll().ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryRepo.GetById(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepo.Update(category);
        }
    }
}
