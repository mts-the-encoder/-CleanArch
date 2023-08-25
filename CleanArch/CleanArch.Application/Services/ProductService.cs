using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        var products = await _repository.GetAllAsync();

        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<CategoryDTO> GetById(int? id)
    {
        var product = await _repository.GetByIdAsync(id);

        return _mapper.Map<CategoryDTO>(product);
    }

    public async Task<ProductDTO> GetProductCategory(int? id)
    {
        var product = await _repository.GetProductCategoryAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task Add(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _repository.CreateAsync(product);
    }

    public async Task Update(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _repository.UpdateAsync(product);
    }

    public async Task DeleteById(int? id)
    {
        var product = _repository.GetByIdAsync(id).Result;

        _ = product is null ? throw new Exception("not found")
            : await _repository.RemoveAsync(product);
    }
}