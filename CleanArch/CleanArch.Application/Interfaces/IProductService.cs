using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAll();
    Task<ProductDTO> GetById(int id);
    Task<IEnumerable<ProductDTO>> GetProductCategory(int id);
    Task<ProductDTO> Add(ProductDTO productDto);
    Task<ProductDTO> Update(ProductDTO productDto);
    Task Delete(int id);
}