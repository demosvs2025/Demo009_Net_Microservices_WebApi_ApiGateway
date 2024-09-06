using System.ComponentModel.DataAnnotations;

namespace SalesBusinessAppMVC.Models
{
    public class ProductCalifornia
    {
        public int ProductId { get; set; }
        [Display(Name = "Product")]
        public required string ProductName { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }

    }
}
