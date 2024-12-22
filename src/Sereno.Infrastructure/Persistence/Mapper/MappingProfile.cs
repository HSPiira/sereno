using AutoMapper;
using Sereno.Infrastructure.Dtos.Inventory;
using Sereno.Infrastructure.Migrations;

namespace Sereno.Infrastructure.Persistence.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateMap<InventoryItem, InventoryItemDto>()
        //     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString("G")));
    }
}