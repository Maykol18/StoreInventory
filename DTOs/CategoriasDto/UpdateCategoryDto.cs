using System.ComponentModel.DataAnnotations;

public class UpdateCategoryDto
{
    [Required]
    public string Name { get; set; } = null!;
}