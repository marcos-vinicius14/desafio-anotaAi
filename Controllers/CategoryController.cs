using DesafioAnotaAi.Model;
using DesafioAnotaAi.Services;
using DesafioAnotaAi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAnotaAi.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryServices _services;

    public CategoryController(CategoryServices services)
    {
        _services = services;
    }
    
    [HttpPost("v1/create-categories")]
    public async Task<IActionResult> CreateCategory(
        [FromBody] CategoryViewModel? model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (model is null)
            return StatusCode(500, new ResultViewModels<CategoryModel>("Não foi possível criar a categoria"));

        var category = await _services.CreateCategoryAsync(model);

        return Created($"v1/create-categories/{category.Id}", category);
    }
}

