using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAll();
    Task<CategoryDTO> GetById(int? id);
    Task<ProductDTO> GetProductCategory(int? id);
    Task Add(ProductDTO productDto);
    Task Update(ProductDTO productDto);
    Task DeleteById(int? id);
}