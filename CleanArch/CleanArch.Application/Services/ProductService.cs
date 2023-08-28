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

    public async Task<ProductDTO> GetById(int? id)
    {
        var product = await _repository.GetByIdAsync(id);

        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<IEnumerable<ProductDTO>> GetProductCategory(int? id)
    {
        var product = await _repository.GetProductCategoryAsync(id);
        return _mapper.Map<IEnumerable<ProductDTO>>(product);
    }

    public async Task<ProductDTO> Add(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _repository.CreateAsync(product);

        return productDto;
    }

    public async Task<ProductDTO> Update(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _repository.UpdateAsync(product);

        return productDto;
    }

    public async Task Delete(int? id)
    {
        var product = _repository.GetByIdAsync(id).Result;

        await _repository.RemoveAsync(product);
    }
}