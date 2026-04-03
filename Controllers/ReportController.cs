using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Data;

[ApiController]
[Route("/api/[controller]")]
public class ReportController : ControllerBase
{
    IProductService _service = new ProductService();
    [HttpGet("top-product")]
    public async Task<IActionResult> GetTopProducts()
    {
        var topProduct = await _service.GetTopProduct();
        return Ok(topProduct);
    }
}