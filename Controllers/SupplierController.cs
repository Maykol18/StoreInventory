using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class SupplierController : ControllerBase
{
    ISupplierService _service = new SupplierService();

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var suppliers = await _service.GetAll();

        return Ok(suppliers);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var supplier = await _service.GetById(id);
        if(supplier == null)
            return NotFound();

        return Ok(supplier);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSupplierDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(new
            {
                Message = "Datos Invalidos",
                Error = ModelState
            });
        await _service.AddSupplier(dto);

        return Created();
    }
    [HttpPut]
    public async Task<IActionResult> Put(int id, UpdateSupplierDto dto)
    {
        var supplier = await _service.GetById(id);
        if(supplier == null)
            return NotFound();
        if(!ModelState.IsValid)
            return BadRequest(new
            {
                Message= "Datos Invalidos",
                Error = ModelState
            });
        await _service.UpdateSupplier(id, dto);
        return Ok(dto);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var supplier = await _service.GetById(id);
        if(supplier == null)
            return NotFound();
        
        await _service.DeleteSuplier(id);
        return NoContent();
    }
}