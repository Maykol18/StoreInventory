public class CreateOrderDto
{
    public List<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();
}