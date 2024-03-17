using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
        CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
        CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        CreateMap<Brand, DeletedBrandResponse>().ReverseMap();
        CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
        CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
        CreateMap<IPaginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();
    }
}