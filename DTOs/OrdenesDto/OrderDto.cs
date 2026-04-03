public class OrderDto
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public decimal Totalamount { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
}