using DesafioAnotaAi.Data.Mappings;
using DesafioAnotaAi.Model;
using DesafioAnotaAi.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioAnotaAi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> contextOptions)
        : base(contextOptions)
    {}

    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMapping());
        modelBuilder.ApplyConfiguration(new ProductMapping());
    }
}