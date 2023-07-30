using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bitirme_Model.ViewModels
{
    public class ShoppingListItemViewModel
    {
        public int ShoppingListId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool Aldimi { get; set; }
        public int Amount { get; set; }
        //public List<SelectListItem> ProductList { get; set; }
    }
}
