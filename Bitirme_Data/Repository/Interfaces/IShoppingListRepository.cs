using Bitirme_Model.Entities;

namespace Bitirme_Data.Repository.Interfaces
{
    public interface IShoppingListRepository
    {
        List<ShoppingList> GetShoppingListsByUserId(string userId);
    }
}
