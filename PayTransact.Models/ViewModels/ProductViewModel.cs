using System.ComponentModel.DataAnnotations;

namespace PayTransact.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage ="*Product name required.")]
        [Display(Name ="Product name", Prompt = "Specify the product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*Product description required.")]
        [Display(Name = "Product desciption", Prompt = "Describe the product you want to create")]
        public string Description { get; set; }

        [Required(ErrorMessage = "*Product amount required.")]
        [Display(Name = "Product amount", Prompt = "Cost of product")]
        public double Amount { get; set; }

        public ProductViewModel()
        {
            Amount = 0;
        }
    }
}
