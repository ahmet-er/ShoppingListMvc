using Bitirme_Data.Context;
using Bitirme_Data.Repository.Interfaces;
using Bitirme_Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bitirme_Data.Repository
{
    public class ShoppingListItemRepository : IShoppingListItemRepository
    {
        private readonly ShoppingListDbContext _context;
        public ShoppingListItemRepository(ShoppingListDbContext context)
        {
            _context = context;
        }

        public ShoppingListItem GetShoppingListItem(int shoppingListId, int productId)
        {
            return _context.ShoppingListItems
                .SingleOrDefault(item => item.ShoppingListId == shoppingListId && item.ProductId == productId);
        }

        public List<ShoppingListItem> GetShoppingListItemByShoppingListId(int shoppingListId)
        {
            return _context.ShoppingListItems
                .Include(sli => sli.Product)
                .Where(sli => sli.ShoppingListId == shoppingListId)
                .ToList();
        }
    }
}
