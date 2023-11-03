using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace VshopWeb.Models;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "this field is mandatory")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "this field is mandatory")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "this field is mandatory")]
    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "this field is mandatory")]
    public long Stock { get; set; }

    [Required(ErrorMessage = "this field is mandatory")]
    public decimal? Price { get; set; }

    public string? CategoryName { get; set; }
    public int CategoryId { get; set; }
}
