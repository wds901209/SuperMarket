using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;

    }
}
