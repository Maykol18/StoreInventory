using MyFirstApi.Data;

public interface ICategoryService
{
    Task<IEnumerable<CategoriaDto>> GetAll();
    Task<CategoriaDto> GetById(int id);
    Task<CategoriaDto> AddCategory(CreateCategoryDto dto);
    Task UpdateCategory(int id, UpdateCategoryDto dto);
    Task Delete(int id);
}