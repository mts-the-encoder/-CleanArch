using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArch.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; private set; }

    [Required(ErrorMessage = "Description is Required")]
    [MinLength(5)]
    [MaxLength(200)]
    public string Description { get; private set; }

    [Required(ErrorMessage = "Price is Required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType((DataType.Currency))]
    [DisplayName("Price")]
    public decimal Price { get; private set; }

    [Required(ErrorMessage = "Stock is Required")]
    [Range(1, 9999)]
    [DisplayName("Stock")]
    public int Stock { get; private set; }

    [MaxLength(250)]
    public string? Image { get; private set; }

    public int CategoryId { get; set; }
    public CategoryDTO Categories { get; set; }
}