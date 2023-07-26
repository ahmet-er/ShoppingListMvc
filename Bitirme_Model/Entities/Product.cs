using Bitirme_Model.Entities.Base;

namespace Bitirme_Model.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? ImageFilePath { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
