using AutoMapper;
using Core.Dtos;
using Entities.Models;
namespace Core.Helper;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, DtoCategory>().ReverseMap();
            /*.ForMember(dest=> dest.CategoryName,
                        opt => opt.MapFrom(
                            src=> src.KategoriAdi));*/
        CreateMap<Customer, DtoCustomer>().ReverseMap();
        CreateMap<Employee, DtoEmployee>().ReverseMap();
        CreateMap<Order, DtoOrder>().ReverseMap();
        CreateMap<OrderDetail, DtoOrderDetail>().ReverseMap();
        CreateMap<Product, DtoProduct>().ReverseMap();
        CreateMap<Region, DtoRegion>().ReverseMap();
        CreateMap<Shipper, DtoShipper>().ReverseMap();
        CreateMap<Supplier, DtoSupplier>().ReverseMap();
        CreateMap<Territory, DtoTerritory>().ReverseMap();
        CreateMap<VwProdCatSup, DtoVwProdCatSup>().ReverseMap();
    }
    /*private IConfigurationProvider MapConfig()
    {
        MappingProfiles mappingProfiles= new ();
        MapperConfiguration configuration = new(x => x.AddProfile(mappingProfiles));
        return configuration;
    }
    public IMapper MatcMap() => new Mapper(MapConfig());*/
    public IMapper MatcMap() => 
        new Mapper(
            new MapperConfiguration(x=>x.AddProfile(
                new MappingProfiles())));
}
