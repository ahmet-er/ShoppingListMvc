using Bitirme_Model.Entities;

namespace Bitirme_Business.Interfaces
{
    public interface IShoppingListItemBusiness
    {
        ShoppingListItem GetShoppingListItem(int shoppingListItemId);
        List<ShoppingListItem> GetAllShoppingList();
        void AddShoppingListItem(ShoppingListItem shoppingListItem);
        void UpdateShoppingListItem(ShoppingListItem shoppingListItem);
        void DeleteShoppingListItem(int shoppingListItemId);
    }
}
