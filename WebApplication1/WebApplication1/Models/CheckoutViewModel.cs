using System.ComponentModel.DataAnnotations;

namespace JewelryStore.Models
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "Ім'я")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Адреса доставки")]
        public string Address { get; set; }
    }
}
