using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;

public class CategoryService : ICategoryService
{
    private readonly InventarioDbContext _context = new InventarioDbContext();
    public async Task<CategoriaDto> AddCategory(CreateCategoryDto dto)
    {
        var category = new Categoria
        {
            Name = dto.Name
        };
        var a = _context.Categoria.Add(category);
        await _context.SaveChangesAsync();

        var categoria = new CategoriaDto
        {
            Name = dto.Name,
            Productos = a.Entity.Productos.Select(p => new ProductoDeCategoriaDto
        {
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock
        }).ToList()
        };
        return categoria;
    }

    public async Task Delete(int id)
    {
        var category = _context.Categoria.Find(id);
        _context.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoriaDto>> GetAll()
    {
        var categories = await _context.Categoria.Select(c => new CategoriaDto
        {
            Name = c.Name,
            Productos = c.Productos.Select(p => new ProductoDeCategoriaDto
        {
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock
        }).ToList()
        }).ToListAsync();
        return categories;
    }

    public async Task<CategoriaDto> GetById(int id)
    {
        var category = _context.Categoria.Where(c => c.Id == id).Select(c => new CategoriaDto
        {
            Name = c.Name,
            Productos = c.Productos.Select(p => new ProductoDeCategoriaDto
        {
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock
        }).ToList()
        }).FirstOrDefault();
        return category;
    }

    public async Task UpdateCategory(int id, UpdateCategoryDto dto)
    {
        var category = _context.Categoria.Find(id);
        category.Name = dto.Name;
        _context.Update(category);
        await _context.SaveChangesAsync();
    }
}