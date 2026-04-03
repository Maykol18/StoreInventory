using Microsoft.EntityFrameworkCore;
using MyFirstApi.Data;

public class SaleService : ISaleService
{
    private readonly InventarioDbContext _context = new InventarioDbContext();

    public async Task<OrderDto> AddOrder(CreateOrderDto dto)
    {
        var sale = new Orden
        {
            Date = DateOnly.FromDateTime(DateTime.Now)

        };
        AddProductToOrder(dto.OrderItems, sale);
        var a = _context.Ordens.Add(sale);
        await _context.SaveChangesAsync();

        var saleDto = new OrderDto
        {
            Id = a.Entity.Id,
            Date = a.Entity.Date,
            Totalamount = a.Entity.Totalamount,
            OrderItems = (List<OrderItemDto>)a.Entity.OrderItems.Select(oi => new OrderItemDto
            {
                Name = oi.Product.Name,
                Price = oi.Price,
                Quantity = oi.Quantity                
            }).ToList()
        };

        return saleDto;
    }
    private void AddProductToOrder(List<CreateOrderItemDto> id, Orden orden)
    {
        foreach (var item in id)
        {
            var producto = _context.Productos.Find(item.id);

            if (item.Quantity > producto.Stock)
            {
                throw new Exception("Not enough Stock");
            }
            var orderItem = new OrderItem
            {
                Productid = item.id,
                Quantity = item.Quantity,
                Price = producto.Price

            };
            orden.OrderItems.Add(orderItem);
            producto.Stock -= item.Quantity;
            orden.Totalamount += producto.Price * item.Quantity;
        }
    }

    public async Task<IEnumerable<OrderDto>> GetAll()
    {
        var sales = await _context.Ordens.Select(s => new OrderDto
        {
            Id = s.Id,
            Date = s.Date,
            Totalamount = s.Totalamount,
            OrderItems = s.OrderItems.Select(oi => new OrderItemDto
            {
                Name = oi.Product.Name,
                Price = oi.Product.Price,
                Quantity = oi.Quantity
            }).ToList()
        }).ToListAsync();
        return sales;
    }

    public async Task<OrderDto> GetById(int id)
    {
        var sale = _context.Ordens.Where(s => s.Id == id).Select(s => new OrderDto
        {
            Id = s.Id,
            Date = s.Date,
            Totalamount = s.Totalamount,
            OrderItems = s.OrderItems.Select(oi => new OrderItemDto
            {
                Name = oi.Product.Name,
                Price = oi.Product.Price,
                Quantity = oi.Quantity
            }).ToList()
        }).FirstOrDefault();

        return sale;
    }

    public async Task<OrderDto> UpdateOrder(int id, CreateOrderDto dto)
    {
        var sale = _context.Ordens.Where(s => s.Id == id).Include(s => s.OrderItems).ThenInclude(oi => oi.Product).First();
        UpdateProductToOrder(dto.OrderItems, sale);
        var a = _context.Ordens.Update(sale);
        await _context.SaveChangesAsync();

        var saleDto = new OrderDto
        {
            Id = a.Entity.Id,
            Date = a.Entity.Date,
            Totalamount = a.Entity.Totalamount,
            OrderItems = (List<OrderItemDto>)a.Entity.OrderItems.Select(oi => new OrderItemDto
            {
                Name = oi.Product.Name,
                Price = oi.Price,
                Quantity = oi.Quantity                
            }).ToList()
        };

        return saleDto;
    }
    private void UpdateProductToOrder(List<CreateOrderItemDto> id, Orden orden)
    {
        foreach (var item in id)
        {
            var producto = _context.Productos.Find(item.id);

            if (item.Quantity > producto.Stock)
            {
                throw new Exception("Not enough Stock");
            }
            var orderitem = orden.OrderItems.First(oi => oi.Productid == item.id);
            if(orderitem.Quantity > item.Quantity)
            {
                producto.Stock += orderitem.Quantity - item.Quantity;
                orden.Totalamount -= (producto.Price * orderitem.Quantity) - (producto.Price * item.Quantity);
            }
            else if(orderitem.Quantity < item.Quantity)
            {
                producto.Stock -= orderitem.Quantity - item.Quantity;               
                orden.Totalamount += (producto.Price * item.Quantity) - (producto.Price * orderitem.Quantity);
            }
            
            orderitem.Quantity = item.Quantity;
        }
    }

    public async Task CancelOrder(int id)
    {
        var order = _context.Ordens.Where(o => o.Id == id).Include(o => o.OrderItems).ThenInclude(oi => oi.Product).First();

        ReturnProductsFromOrder(order.OrderItems);

        await _context.SaveChangesAsync();
        _context.Remove(order);

        await _context.SaveChangesAsync();
    }

    
    private void ReturnProductsFromOrder(ICollection<OrderItem> orderItems)
    {
        foreach (var item in orderItems)
        {
            var product = _context.Productos.Find(item.Product.Id);

            product.Stock += item.Quantity;
        }
    }
}