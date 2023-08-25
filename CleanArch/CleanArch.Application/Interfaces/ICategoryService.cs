using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAll();
    Task<CategoryDTO> GetById(int? id);
    Task Add(CategoryDTO categoryDTO);
    Task Update(CategoryDTO categoryDTO);
    Task Delete(int? id);
}