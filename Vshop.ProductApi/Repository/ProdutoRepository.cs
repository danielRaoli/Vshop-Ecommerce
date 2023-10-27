using Microsoft.EntityFrameworkCore;
using Vshop.ProductApi.Data;
using Vshop.ProductApi.Models;

namespace Vshop.ProductApi.Repository;

public class ProdutoRepository : IProductRepository
{
    private AppDbContext _context;
    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Product> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetById(int id)
    {
         return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> Remove(int id)
    {
        var product = await GetById(id);
        _context.Remove(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return product;
    }
}
