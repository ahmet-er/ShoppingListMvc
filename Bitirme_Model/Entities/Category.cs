using Bitirme_Model.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Bitirme_Model.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
