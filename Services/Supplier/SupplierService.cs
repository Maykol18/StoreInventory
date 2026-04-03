using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;

public class SupplierService : ISupplierService
{
    private InventarioDbContext _context = new InventarioDbContext();
    public async Task<SupplierDto> AddSupplier(CreateSupplierDto dto)
    {
        var supplier = new Proveedor
        {
            Name = dto.Name
        };
        var a = _context.Add(supplier);
        await _context.SaveChangesAsync();

        var supplierdto = new SupplierDto
        {
            Name = dto.Name,
            Productos = a.Entity.Productos.Select(p => new ProductoDeProveedorDto
            {
                Name = p.Name

            }).ToList()
        };

        return supplierdto;
    }

    public async Task DeleteSuplier(int id)
    {
        var supplier = _context.Proveedors.Find(id);
        _context.Proveedors.Remove(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<SupplierDto>> GetAll()
    {
        var suppliers = await _context.Proveedors.Select(s => new SupplierDto
        {
            Name = s.Name,
            Productos = s.Productos.Select(p => new ProductoDeProveedorDto
            {
                Name = p.Name
            }).ToList()
        }).ToListAsync();

        return suppliers;
    }

    public async Task<SupplierDto> GetById(int id)
    {
        var supplier = _context.Proveedors.Where(s => s.Id == id).Select(s => new SupplierDto
        {
            Name = s.Name,
            Productos = s.Productos.Select(p => new ProductoDeProveedorDto
            {
                Name = p.Name
            }).ToList()
        }).FirstOrDefault();

        return supplier;
    }

    public async Task UpdateSupplier(int id, UpdateSupplierDto dto)
    {
        var supplier = _context.Proveedors.Find(id);
        supplier.Name = dto.Name;
        _context.Update(supplier);
        await   _context.SaveChangesAsync();
    }
}