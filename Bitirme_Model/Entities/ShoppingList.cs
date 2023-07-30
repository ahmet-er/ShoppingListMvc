using Bitirme_Model.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Bitirme_Model.Entities
{
    public class ShoppingList /*: BaseEntity*/
    {
        public ShoppingList()
        {
            Products = new HashSet<ShoppingListItem>();
        }
        public int ShoppingListID { get; set; }
        public string Name { get; set; }
        public bool AlisveriseCikildiMi { get; set; }
        public bool AlisverisTamamlandiMi { get; set; }
        public string UserID { get; set; }
        public AppUser User { get; set; }
        public ICollection<ShoppingListItem> Products { get; set; }
    }
}
