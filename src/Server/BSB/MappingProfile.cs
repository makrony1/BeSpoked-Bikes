using AutoMapper;

namespace BSB;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<Models.Models.Customer, Models.Entity.Customer>().ReverseMap();
        this.CreateMap<Models.Models.Product, Models.Entity.Product>().ReverseMap();
        this.CreateMap<Models.Models.Salesperson, Models.Entity.Salesperson>().ReverseMap();
        this.CreateMap<Models.Entity.Sales, Models.Models.Sales>().
            ForMember(dest => dest.SalespersonName, opt => opt.MapFrom(src => $"{src.Salesperson.FirstName} {src.Salesperson.LastName}")).
            ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}")).
            ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => $"{src.Product.Name}"));
    }
}
