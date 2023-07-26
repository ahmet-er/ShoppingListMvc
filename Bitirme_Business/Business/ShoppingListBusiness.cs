using Bitirme_Business.Interfaces;
using Bitirme_Data.Repository.Interfaces;
using Bitirme_Model.Entities;

namespace Bitirme_Business.Business
{
    public class ShoppingListBusiness : IShoppingListBusiness
    {
        private readonly IGenericRepository<ShoppingList> _shoppingListRepo;

        public ShoppingListBusiness(IGenericRepository<ShoppingList> shoppingListRepo)
        {
            _shoppingListRepo = shoppingListRepo;
        }

        public void AddShoppingList(ShoppingList shoppingList)
        {
            _shoppingListRepo.Add(shoppingList);
        }

        public void DeleteShoppingList(int shoppingId)
        {
            var shoppingList = _shoppingListRepo.GetById(shoppingId);
            _shoppingListRepo.Delete(shoppingList);
        }

        public List<ShoppingList> GetAllShoppingList()
        {
            return _shoppingListRepo.GetAll().ToList();
        }

        public ShoppingList GetShoppingListById(int shoppingId)
        {
            return _shoppingListRepo.GetById(shoppingId);
        }

        public void UpdateShoppingList(ShoppingList shoppingList)
        {
            _shoppingListRepo.Update(shoppingList);
        }
    }
}
