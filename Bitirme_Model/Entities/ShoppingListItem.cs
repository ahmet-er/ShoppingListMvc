namespace Bitirme_Model.Entities
{
    public class ShoppingListItem
    {
        public int ShoppingListId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public bool Aldimi { get; set; }
        public int Amount { get; set; }
        public ShoppingList ShoppingList { get; set; }
        public Product Product { get; set; }
    }
}
