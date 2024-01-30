using System.ComponentModel.DataAnnotations;
using DesafioAnotaAi.Model;

namespace DesafioAnotaAi.ViewModels;

public class ProductViewModel
{
    [Required(ErrorMessage = "O produto deve conter um nome.")]
    [MaxLength(60, ErrorMessage = "O máximo de caracteres é 60!")]
    [MinLength(5, ErrorMessage = "O nome deve conter no minímo 5 caracteres")]
    public string Title { get; set; }   = String.Empty;
    
    [MaxLength(120, ErrorMessage = "O máximo de caracteres é 120!")]
    public string Description { get; set; } = String.Empty;

    [Required(ErrorMessage = "Informe um preço!")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    public int OwnerId { get; set; }

    public CategoryModel Category { get; set; } = new();

}

