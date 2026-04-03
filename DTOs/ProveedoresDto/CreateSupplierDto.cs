using System.ComponentModel.DataAnnotations;

public class CreateSupplierDto
{
    [Required]
    public string Name { get; set; }
}