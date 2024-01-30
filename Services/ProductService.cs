using DesafioAnotaAi.Data;
using DesafioAnotaAi.Models;
using DesafioAnotaAi.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DesafioAnotaAi.Services;

public class ProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<ProductModel> CreateProductAsync(ProductViewModel model)
    {
        var product = new ProductModel(model);

        if (product is null)
            throw new Exception("Não foi possível criar um produto. Tente novamente!");

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<List<ProductModel>> GetAllProductsAsync()
    {
        var products = await _context
            .Products
            .AsNoTracking()
            .ToListAsync();

        return products;
    }

    public async Task<ProductModel> UpdateProductAsync(int id, ProductViewModel model)
    {
        var product = await _context
            .Products
            .FirstOrDefaultAsync(x => x.Id == id);

        if (product is null)
            throw new Exception("Produto não encontrado");

        product.Title = model.Title;
        product.Description = model.Description;
        product.Price = model.Price;
        product.Category = model.Category;

        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<ProductModel> DeleteProductAsync(int id)
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
}