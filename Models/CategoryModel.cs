using DesafioAnotaAi.Models;
using DesafioAnotaAi.ViewModels;

namespace DesafioAnotaAi.Model;

public class CategoryModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public List<ProductModel> ListProducts { get; set; } = new();

    public CategoryModel(CategoryViewModel model)
    {
        Title = model.Title;
        Description = model.Description;
        OwnerId = model.OwnerId;
    }
}