using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product?>> GetAllAsync();
    Task<Product?> GetByIdAsync(int? id);
    Task<IEnumerable<Product?>> GetProductCategoryAsync(int? id);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task RemoveAsync(Product product);
}
