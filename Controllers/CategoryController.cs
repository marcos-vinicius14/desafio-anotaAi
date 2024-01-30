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
    
    [HttpPost("/v1/categories")]
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

    [HttpGet("/v1/categories")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var categories = await _services.GetAllCategoriesAsync();
        return Ok(new ResultViewModels<List<CategoryModel>>(categories));
    }

    [HttpPut("/v1/categories/{id:int}")]
    public async Task<IActionResult> UpdateCategoryAsync(
        [FromRoute] int id,
        [FromBody] CategoryViewModel? model)
    {
        if (model is null)
            return NotFound();

        var category = await _services.UpdateCategoryAsync(id, model);

        return Ok(new ResultViewModels<CategoryModel>(category));
    }
}

