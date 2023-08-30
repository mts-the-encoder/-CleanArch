using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Products.Commands;

namespace CleanArch.Application.Mapper;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ProductDTO, ProductUpdateCommand>().ReverseMap();

        CreateMap<ProductDTO, ProductCreateCommand>().ReverseMap();
    }
}