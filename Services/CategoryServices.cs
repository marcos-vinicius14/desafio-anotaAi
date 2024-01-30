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

    public async Task<CategoryModel> UpdateCategoryAsync(int id,
        CategoryViewModel? model)
    {
        var category = await _context
            .Categories
            .FirstOrDefaultAsync(x => x.Id == id);
        
        if(category is null)
            throw new Exception("A categoria não existe");

        category.Title = model.Title;
        category.Description = model.Description;

         _context.Categories.Update(category);
         await _context.SaveChangesAsync();

         return category;
    }

    public async Task<CategoryModel> DeleteCategoryAsync(int id)
    {
        var categoryForDelete = await _context
            .Categories
            .FirstOrDefaultAsync(x => x.Id == id);
        if (categoryForDelete is null)
            throw new Exception("Categoria não encontrada.");

        _context.Categories.Remove(categoryForDelete);
        await _context.SaveChangesAsync();

         return categoryForDelete;
    }
}
