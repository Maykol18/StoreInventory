
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;

public class ProductService : IProductService
{
    private readonly InventarioDbContext _context = new InventarioDbContext();

    public async Task<ProductoDto> AddProduct(CreateProductDto dto)
    {
        var product =  new Producto
        {
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock,
            CategoriaId = dto.CategoriaId,
            ProveedorId = dto.ProveedorId
        };
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        var producto = new ProductoDto
        {
            Name = dto.Name,
            Price = dto.Price,
            Categoria = _context.Categoria.Find(dto.CategoriaId).Name,
            Proveedor = _context.Proveedors.Find(dto.ProveedorId).Name
        };

        return producto;
    }

    public async Task Delete(int id)
    {
        var product = _context.Productos.Find(id);
        _context.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProductoDto>> GetAll()
    {
        return await _context.Productos.Select(p => new ProductoDto
        {
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            Categoria = p.Categoria.Name,
            Proveedor = p.Proveedor.Name
        }).ToListAsync();
    }

    public async Task<ProductoDto> GetById(int id)
    {
        return _context.Productos.Where(p => p.Id == id).Select(p => new ProductoDto
        {
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            Categoria = p.Categoria.Name,
            Proveedor = p.Proveedor.Name
        }).FirstOrDefault();
    }

    public async Task<TopProductDto> GetTopProduct()
    {
        var topProduct = _context.OrderItems.GroupBy(oi => oi.Product).Select(g => new TopProductDto
        {
            ProductName = g.Key.Name,
            TotalSold = g.Sum(p => p.Quantity)
        }).OrderByDescending(p => p.TotalSold).First();

        return topProduct;
    }

    public async Task UpdateProduct(int id, UpdateProductDto dto)
    {
        var product = _context.Productos.Find(id);
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.CategoriaId = dto.CategoriaId;
        product.ProveedorId = dto.ProveedorId;
        _context.Update(product);
        await _context.SaveChangesAsync();
    }

}