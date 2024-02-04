using DesafioAnotaAi.Data;
using DesafioAnotaAi.Models;
using DesafioAnotaAi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DesafioAnotaAi.Services;

public class ProductService
{
    private readonly DataContext _context;
    private readonly CategoryServices _categoryServices;

    public ProductService(DataContext context, CategoryServices categoryServices)
    {
        _context = context;
        _categoryServices = categoryServices;
    }

    public async Task<ProductModel> CreateProductAsync(ProductViewModel model)
    {
        var category = await _categoryServices.GetCategoryByIdAsync(model.Category.Id);
        if (category is null)
            throw new InvalidOperationException("Categoria não encontrada!");
        
        var product = new ProductModel(model);
        product.Category = category;

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<ProductModel>> GetAllProductsAsync()
    {
        try
        {
            var products = await _context
                .Products
                .AsNoTracking()
                .ToListAsync();
            
            return products;

        }
        catch
        {
            throw new Exception("Falha interna no servidor");
        }

    }

    public async Task<ProductModel> UpdateProductAsync(int id, ProductViewModel model)
    {
        try
        {
            var product = await _context
                .Products
                .FirstOrDefaultAsync(x => x.Id == id);
            
            product.Title = model.Title;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Category = model.Category;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
        catch
        {
            throw new Exception("Produto não encontrado");
        }
        
    }

    public async Task<ProductModel> DeleteProductAsync(int id)
    {
        try
        {
            var productFromDelete = await _context
                .Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productFromDelete is null)
                throw new Exception("Produto não encontrado!");

            _context.Products.Remove(productFromDelete);
            await _context.SaveChangesAsync();

            return productFromDelete;
        }
        catch 
        {
            throw new Exception("Falha interna no servidor");
        }
    }
}