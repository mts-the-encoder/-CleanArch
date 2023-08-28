using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mapper;

public class DomainToDTO : Profile
{
    public DomainToDTO()
    {
        CreateMap<Category, CategoryDTO>()
         .ForMember(dto => dto.Id,map => map.MapFrom(c => c.Id));

        CreateMap<CategoryDTO, Category>()
            .ForMember(c => c.Id,map => map.MapFrom(dto => dto.Id));

        CreateMap<Product, ProductDTO>().ReverseMap()
            .ForMember(dto => dto.Id,map => map.MapFrom(c => c.Id));
        CreateMap<ProductDTO, Product>().ReverseMap()
            .ForMember(dto => dto.Id,map => map.MapFrom(c => c.Id));
    }
}