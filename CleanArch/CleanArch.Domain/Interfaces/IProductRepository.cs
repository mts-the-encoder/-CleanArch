﻿using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product category);
    Task<Product> UpdateAsync(Product category);
    Task<Product> RemoveAsync(Product category);
}
