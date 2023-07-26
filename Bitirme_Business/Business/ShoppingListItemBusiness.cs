using Bitirme_Business.Interfaces;
using Bitirme_Data.Repository.Interfaces;
using Bitirme_Model.Entities;

namespace Bitirme_Business.Business
{
    public class ShoppingListItemBusiness : IShoppingListItemBusiness
    {
        private readonly IGenericRepository<ShoppingListItem> _shoppingListItemRepo;

        public ShoppingListItemBusiness(IGenericRepository<ShoppingListItem> shoppingListItemRepo)
        {
            _shoppingListItemRepo = shoppingListItemRepo;
        }

        public void AddShoppingListItem(ShoppingListItem shoppingListItem)
        {
            _shoppingListItemRepo.Add(shoppingListItem);
        }

        public void DeleteShoppingListItem(int shoppingListItemId)
        {
            var shoppingListItem = _shoppingListItemRepo.GetById(shoppingListItemId);
            _shoppingListItemRepo.Delete(shoppingListItem);
        }

        public List<ShoppingListItem> GetAllShoppingList()
        {
            return _shoppingListItemRepo.GetAll().ToList();
        }

        public ShoppingListItem GetShoppingListItem(int shoppingListItemId)
        {
            return _shoppingListItemRepo.GetById(shoppingListItemId);
        }

        public void UpdateShoppingListItem(ShoppingListItem shoppingListItem)
        {
            _shoppingListItemRepo.Update(shoppingListItem);
        }
    }
}
