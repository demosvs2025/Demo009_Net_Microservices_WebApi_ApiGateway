using System.ComponentModel.DataAnnotations;

namespace SalesBusinessAppMVC.Models
{
    public class ProductNewYork
    {
        public int ProductId { get; set; }
        [Display(Name = "Product name")]
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
