using System.ComponentModel.DataAnnotations;
using Vshop.ProductApi.Models;

namespace Vshop.ProductApi.Dto;

public class ProductDto
{
    public int Id { get; set; }
    [Required(ErrorMessage ="This name is required")]
    [MaxLength(100)]
    [MinLength(3)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "This Price is required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "This description is required")]
    public string Description { get; set; }

    [Required(ErrorMessage =" this value stock is required")]
    [Range(1,9999)]
    public long Stock { get; set; }

    public string ImageUrl { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
