using DesafioAnotaAi.Model;

namespace DesafioAnotaAi.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public CategoryModel? Category { get; set; }

}
