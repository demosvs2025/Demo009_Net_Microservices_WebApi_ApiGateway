using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsNewYorkAPI.Models
{
    [Table("Products")]
    public class ProductNewYork
    {
        [Key]
        public int ProductId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
