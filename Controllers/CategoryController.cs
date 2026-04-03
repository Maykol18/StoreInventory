using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/[controller]")]
public class CategoryController : ControllerBase
{
    ICategoryService _service = new CategoryService();

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _service.GetAll();

        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _service.GetById(id);
        if(category == null)
            return NotFound();

        return Ok(category);
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateCategoryDto dto)
    {
        if(!ModelState.IsValid)
            return BadRequest(new
            {
                Message = "Datos invalidos",
                Errors = ModelState
            });
        
        var category = await _service.AddCategory(dto);
        
        return Created();
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, UpdateCategoryDto dto)
    {
        var category = await _service.GetById(id);
        if(category == null)
            return NotFound();
        if(!ModelState.IsValid)
            return BadRequest(new
            {
                Message = "Datos invalidos",
                Errors = ModelState
            });
        await _service.UpdateCategory(id, dto);

        return Ok(dto);
    }

    [HttpDelete]

    public async Task<IActionResult> Delete(int id)
    {
        var category = await _service.GetById(id);
        if(category == null)
            return NotFound();
        
        _service.Delete(id);

        return NoContent();
    }
}