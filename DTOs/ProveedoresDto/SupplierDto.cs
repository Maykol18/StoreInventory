public class SupplierDto
{
    public string Name { get; set; }
    public List<ProductoDeProveedorDto> Productos {get; set;} = new List<ProductoDeProveedorDto>();
}