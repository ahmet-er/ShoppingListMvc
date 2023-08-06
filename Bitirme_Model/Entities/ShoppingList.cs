namespace Bitirme_Model.Entities
{
    public class ShoppingList
    {
        public ShoppingList()
        {
            Products = new HashSet<ShoppingListItem>();
        }
        public int ShoppingListID { get; set; }
        public string Name { get; set; }
        public bool AlisveriseCikildiMi { get; set; }
        public string UserID { get; set; }
        public AppUser User { get; set; }
        public ICollection<ShoppingListItem> Products { get; set; }
    }
}
