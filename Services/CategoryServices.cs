using DesafioAnotaAi.Data;
using DesafioAnotaAi.Model;
using DesafioAnotaAi.ViewModels;
using Microsoft.EntityFrameworkCore;
using RestSharp;

namespace DesafioAnotaAi.Services;

public class CategoryServices
{
    private readonly DataContext _context;

    public CategoryServices(DataContext context)
    {
        _context = context;
    }
    
    public async Task<CategoryModel> CreateCategoryAsync(CategoryViewModel model)
    {
        var category = new CategoryModel(model);

        if (category is null)
            throw new Exception("Não foi possível criar a categoria");

        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<List<CategoryModel>> GetAllCategoriesAsync()
    {
        var categories = await _context
            .Categories
            .AsNoTracking()
            .ToListAsync();

        if (categories is null)
            throw new Exception("Categoria não encontrada");

        return categories;
        
    }
}
