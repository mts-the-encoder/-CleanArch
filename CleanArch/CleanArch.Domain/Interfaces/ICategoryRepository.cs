﻿using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int? id);
    Task<Category?> CreateAsync(Category? category);
    Task<Category> UpdateAsync(Category category);
    Task<Category> RemoveAsync(Category category);
}
