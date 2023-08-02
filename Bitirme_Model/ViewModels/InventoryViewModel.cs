using Bitirme_Model.Entities;
using X.PagedList;

namespace Bitirme_Model.ViewModels
{
    public class InventoryViewModel
    {
        public IPagedList<Category>? Categories { get; set; }
        public IPagedList<Product>? Products { get; set; }
    }
}
