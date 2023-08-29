using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mapper;

public class DomainToDTO : Profile
{
    public DomainToDTO()
    {
        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();

        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<ProductDTO, Product>().ReverseMap();
    }
}