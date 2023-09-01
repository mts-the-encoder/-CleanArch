using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;
    public ProductController(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
    {
        var response = await _service.GetAll();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetById(int id)
    {
        var response = await _service.GetById(id);

        return Ok(response);
    }

    [HttpGet("Category/{id}")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductCategoryById(int id)
    {
        var response = await _service.GetProductCategory(id);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> Create(ProductDTO product)
    {
        await _service.Add(product);

        return Created(string.Empty,_mapper.Map<ProductDTO>(product));
    }

    [HttpPut]
    public async Task<ActionResult<ProductDTO>> Update(ProductDTO product)
    {
        var response = await _service.Update(product);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.Delete(id);

        return Ok();
    }
}