using Microsoft.AspNetCore.Identity;

namespace Bitirme_Model.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            ShoppingLists = new HashSet<ShoppingList>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<ShoppingList>? ShoppingLists { get; set; }
    }
}
