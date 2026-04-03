using MyFirstApi.Data;

public interface IProductService
{
    Task<IEnumerable<ProductoDto>> GetAll();
    Task<ProductoDto> GetById(int id);
    Task<ProductoDto> AddProduct(CreateProductDto dto);
    Task UpdateProduct(int id, UpdateProductDto dto);
    Task Delete(int id);
    Task<TopProductDto> GetTopProduct();
}