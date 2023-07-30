using Bitirme_Model.Entities;

namespace Bitirme_Business.Interfaces
{
    public interface IShoppingListBusiness
    {
        ShoppingList GetShoppingListById(int shoppingId);
        List<ShoppingList> GetAllShoppingList();
        List<ShoppingList> GetShoppingListsByUserId(string userId);
        void AddShoppingList(ShoppingList shoppingList);
        void UpdateShoppingList(ShoppingList shoppingList);
        void DeleteShoppingList(int shoppingId);
    }
}
