using System.ComponentModel.DataAnnotations;

public class CreateCategoryDto
{
    [Required]
    public string Name { get; set; } = null!;
}