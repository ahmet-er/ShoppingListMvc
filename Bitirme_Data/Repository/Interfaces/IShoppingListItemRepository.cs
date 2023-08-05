using Bitirme_Model.Entities;

namespace Bitirme_Data.Repository.Interfaces
{
    public interface IShoppingListItemRepository
    {
        List<ShoppingListItem> GetShoppingListItemByShoppingListId(int shoppingListId);
        ShoppingListItem GetShoppingListItem(int shoppingListId, int productId);
    }
}
