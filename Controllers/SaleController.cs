using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISaleService _service = new SaleService();

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sales = await _service.GetAll();
        return Ok(sales);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var sale = await _service.GetById(id);
        if(sale == null)
        {
            return NotFound();
        }

        return Ok(sale);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateOrderDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(new
            {
                Message = "Datos Invalidos",
                Error = ModelState
            });
        var sale = await _service.AddOrder(dto);

        return Ok(sale);
    }
    
    [HttpPut]
    public async Task<IActionResult> ModifyOrder(int id, CreateOrderDto dto)
    {
        var sale = await _service.GetById(id);
        if(sale == null)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                Message ="Datos Invalidos",
                Error = ModelState
            });
        }

        var modifiedSale = await _service.UpdateOrder(id, dto);

        return Ok(modifiedSale);
    }

    [HttpDelete]
    public async Task<IActionResult> CancelOrder(int id)
    {
        var sale = await _service.GetById(id);
        if(sale == null)
        {
            return NotFound();
        }

        await _service.CancelOrder(id);

        return NoContent();
    }
}