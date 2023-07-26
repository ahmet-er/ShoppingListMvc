using Microsoft.AspNetCore.Identity;

namespace Bitirme_Model.Entities
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public List<ShoppingList>? ShoppingLists { get; set; }
    }
}
