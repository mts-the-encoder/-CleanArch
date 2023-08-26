using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetAll();
    Task<CategoryDTO> GetById(int? id);
    Task<CategoryDTO> Add(CategoryDTO request);
    Task Update(CategoryDTO categoryDTO);
    Task Delete(int? id);
}