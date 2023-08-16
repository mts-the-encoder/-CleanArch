using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;

namespace CleanArch.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> CreateAsync(Product category)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> UpdateAsync(Product category)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> RemoveAsync(Product category)
    {
        throw new NotImplementedException();
    }
}