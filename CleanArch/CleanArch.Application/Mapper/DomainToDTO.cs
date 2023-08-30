using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mapper;

public class DomainToDTO : Profile
{
    public DomainToDTO()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();

        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}