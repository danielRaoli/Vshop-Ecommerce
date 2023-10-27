using Microsoft.EntityFrameworkCore;
using Vshop.ProductApi.Data;
using Vshop.ProductApi.Models;

namespace Vshop.ProductApi.Repository;

public class CategoryRepository : ICategoryRepository
{
    private AppDbContext _context;
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Category> Create(Category product)
    {
        _context.Categories.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Category> GetById(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

        
    }

    public async Task<List<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
        
    }

    public async Task<List<Category>> GetProductsCategory()
    {
        return await _context.Categories.Include(c => c.Products).ToListAsync();
    }

    public async Task<Category> Remove(int id)
    {
        var category = await GetById(id);
        _context.Remove(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> Update(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return category;
    }


}
