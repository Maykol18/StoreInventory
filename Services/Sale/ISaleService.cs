using MyFirstApi.Data;

public interface ISaleService
{
    Task<IEnumerable<OrderDto>> GetAll();
    Task<OrderDto> GetById(int id);
    Task<OrderDto> AddOrder(CreateOrderDto dto);
    Task<OrderDto> UpdateOrder(int id, CreateOrderDto dto);
    Task CancelOrder(int id);
}