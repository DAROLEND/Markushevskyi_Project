using System.ComponentModel.DataAnnotations;

namespace JewelryStore.Models
{
    public class Jewelry
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Display(Name = "Матеріал")]
        public string Material { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Range(0.01, 100000)]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }
    }
}
