using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bitirme_Model.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? ImageFilePath { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
