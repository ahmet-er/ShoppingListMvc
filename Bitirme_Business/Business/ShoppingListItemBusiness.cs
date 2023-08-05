using Bitirme_Business.Interfaces;
using Bitirme_Data.Repository.Interfaces;
using Bitirme_Model.Entities;

namespace Bitirme_Business.Business
{
    public class ShoppingListItemBusiness : IShoppingListItemBusiness
    {
        private readonly IGenericRepository<ShoppingListItem> _shoppingListItemRepo;
        private readonly IShoppingListItemRepository _customShoppingListItemRepo;

        public ShoppingListItemBusiness(IGenericRepository<ShoppingListItem> shoppingListItemRepo, IShoppingListItemRepository customShoppingListItemRepo)
        {
            _shoppingListItemRepo = shoppingListItemRepo;
            _customShoppingListItemRepo = customShoppingListItemRepo;
        }

        public void AddShoppingListItem(ShoppingListItem shoppingListItem)
        {
            _shoppingListItemRepo.Add(shoppingListItem);
        }

        public void DeleteShoppingListItem(ShoppingListItem shoppingListItem)
        {
            _shoppingListItemRepo.Delete(shoppingListItem);
        }

        public List<ShoppingListItem> GetAllShoppingList()
        {
            return _shoppingListItemRepo.GetAll().ToList();
        }

        public List<ShoppingListItem> GetItemsByShoppingListId(int shoppingListItemId)
        {
            return _customShoppingListItemRepo.GetShoppingListItemByShoppingListId(shoppingListItemId);
        }

        public ShoppingListItem GetShoppingListItem(int shoppingListItemId)
        {
            return _shoppingListItemRepo.GetById(shoppingListItemId);
        }

        public ShoppingListItem GetShoppingListItemByShoppingListIdAndProductId(int shoppingListId, int productId)
        {
            return _customShoppingListItemRepo.GetShoppingListItem(shoppingListId, productId);
        }

        public void UpdateShoppingListItem(ShoppingListItem shoppingListItem)
        {
            _shoppingListItemRepo.Update(shoppingListItem);
        }
    }
}