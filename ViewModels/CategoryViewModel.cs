using System.ComponentModel.DataAnnotations;

namespace DesafioAnotaAi.ViewModels;


public class CategoryViewModel
{
    [Required(ErrorMessage = "É necessário um título para criar uma categoria!")]
    [MaxLength(25, ErrorMessage = "O máximo de caracteres é 25.")]
    [MinLength(5, ErrorMessage = "O minimo de caracteres é 5.")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Adicione uma descrição a categoria")]
    [MaxLength(150, ErrorMessage = "O máximo de caracteres é 150")]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "É necessário adicionar um Id!")]
    public int OwnerId { get; set; }
}
