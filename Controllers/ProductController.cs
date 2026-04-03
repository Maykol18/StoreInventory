using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class ProductController : ControllerBase
{
    IProductService service = new ProductService();

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await service.GetAll();

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await service.GetById(id);
        if (product == null)
            return NotFound();

        return Ok(product);

    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                Message = "Datos invalidos",
                Errors = ModelState
            });
        }
        var product = await service.AddProduct(dto);

        return Created("GetById", product);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, UpdateProductDto dto)
    {
        if (await service.GetById(id) == null)
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await service.UpdateProduct(id, dto);

        return Ok(dto);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        if (await service.GetById(id) == null)
            return NotFound();
        await service.Delete(id);

        return NoContent();
    }
}