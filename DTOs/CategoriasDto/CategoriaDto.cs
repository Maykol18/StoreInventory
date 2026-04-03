using MyFirstApi.Data;

public class CategoriaDto
{

    public string Name { get; set; } = null!;

    public virtual List<ProductoDeCategoriaDto> Productos { get; set; } = new List<ProductoDeCategoriaDto>();
}