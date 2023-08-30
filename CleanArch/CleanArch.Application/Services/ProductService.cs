using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        var products = new GetProductsQuery();

        if (products is null) throw new ApplicationException("$Entity could not be loaded.");

        var result = await _mediator.Send(products);

        return _mapper.Map<IEnumerable<ProductDTO>>(result);
    }

    public async Task<ProductDTO> GetById(int id)
    {
        var product = new GetProductByIdQuery(id);

        if (product is null) throw new ApplicationException("$Entity could not be loaded.");

        var result = await _mediator.Send(product);

        return _mapper.Map<ProductDTO>(result);
    }

    public async Task<IEnumerable<ProductDTO>> GetProductCategory(int id)
    {
        var products = new GetProductsQuery();

        if (products is null) throw new ApplicationException("$Entity could not be loaded.");

        var productsMediator = await _mediator.Send(products);

        var response = productsMediator.Where(x => x.CategoryId == id);

        return _mapper.Map<IEnumerable<ProductDTO>>(response);
    }

    public async Task<ProductDTO> Add(ProductDTO productDto)
    {
        var product = _mapper.Map<ProductCreateCommand>(productDto);

        var response = await _mediator.Send(product);

        return _mapper.Map<ProductDTO>(response);
    }

    public async Task<ProductDTO> Update(ProductDTO productDto)
    {
        var product = _mapper.Map<ProductUpdateCommand>(productDto);

        var response = await _mediator.Send(product);

        return _mapper.Map<ProductDTO>(response);
    }

    public async Task Delete(int id)
    {
        var product = new ProductRemoveCommand(id);

        await _mediator.Send(product);
    }
}