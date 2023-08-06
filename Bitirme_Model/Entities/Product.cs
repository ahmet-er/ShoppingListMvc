namespace Bitirme_Model.Entities
{
    public class Product
    {
        public Product()
        {
            ShoppingLists = new HashSet<ShoppingListItem>();
        }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string? ImageFilePath { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<ShoppingListItem> ShoppingLists { get; set; }
    }
}
