using System.ComponentModel.DataAnnotations;

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = null!;
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int CategoriaId { get; set; }

    public int ProveedorId { get; set; }
}