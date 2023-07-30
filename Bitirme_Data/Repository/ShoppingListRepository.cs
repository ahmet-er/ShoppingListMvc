using Bitirme_Data.Context;
using Bitirme_Data.Repository.Interfaces;
using Bitirme_Model.Entities;

namespace Bitirme_Data.Repository
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private readonly ShoppingListDbContext _context;
        public ShoppingListRepository(ShoppingListDbContext context)
        {
            _context = context;
        }
        public List<ShoppingList> GetShoppingListsByUserId(string userId)
        {
            return _context.ShoppingLists
                .Where(s => s.UserID == userId)
                .ToList();
        }
    }
}
