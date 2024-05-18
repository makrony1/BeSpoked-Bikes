using AutoMapper;

namespace BSB;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<Models.Models.Customer, Models.Entity.Customer>().ReverseMap();
    }
}
