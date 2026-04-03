using System.ComponentModel.DataAnnotations;

public class UpdateSupplierDto
{
    [Required]
    public string Name { get; set; }
    
}