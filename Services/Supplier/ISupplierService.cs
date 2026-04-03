using MyFirstApi.Data;

public interface ISupplierService
{
    Task<IEnumerable<SupplierDto>> GetAll();
    Task<SupplierDto> GetById(int id);
    Task<SupplierDto> AddSupplier(CreateSupplierDto dto);
    Task UpdateSupplier(int id, UpdateSupplierDto dto);
    Task DeleteSuplier(int id);
}