using Bitirme_Model.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Bitirme_Model.Entities
{
    public class ShoppingList : BaseEntity
    {
        [Required]
        [MaxLength(50, ErrorMessage = "50 Karekteri Aştınız")]
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool AlisveriseCikildiMi { get; set; }
        public bool AlisverisTamamlandiMi { get; set; }
        public AppUser User { get; set; }
        public List<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
