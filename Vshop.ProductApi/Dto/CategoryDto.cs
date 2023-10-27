using System.ComponentModel.DataAnnotations;
using Vshop.ProductApi.Models;

namespace Vshop.ProductApi.Dto;

public class CategoryDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "this name category is required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}
