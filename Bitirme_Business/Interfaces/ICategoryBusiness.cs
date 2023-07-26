using Bitirme_Model.Entities;

namespace Bitirme_Business.Interfaces
{
    public interface ICategoryBusiness
    {
        Category GetCategoryById(int categoryId);
        List<Category> GetAllCategories();
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
