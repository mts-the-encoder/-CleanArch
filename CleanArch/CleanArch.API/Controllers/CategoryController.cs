using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[ApiController]
[Route("[controller]")]

//tenho que arrumar esses métodos tudo.
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAll()
    {
        var response = await _service.GetAll();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetById(int id)
    {
        var response = await _service.GetById(id);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> Create(CategoryDTO category)
    {
        await _service.Add(category);

        return Created(string.Empty, _mapper.Map<CategoryDTO>(category));
    }

    [HttpPut]
    public async Task<ActionResult> Update(CategoryDTO category)
    {
        await _service.Update(category);

        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.Delete(id);

        return Ok();
    }
}
