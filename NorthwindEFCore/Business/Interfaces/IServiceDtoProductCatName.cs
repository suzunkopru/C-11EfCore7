using Entities.Models;
using Entities.DTOs;
namespace Business.Interfaces;
public interface IServiceDtoProductCatName : IService<Product> 
{
    IQueryable<DtoProductCatName> GetProductsCatName();
    public IQueryable<DtoProductCatName> GetProductsCatName
        (int id = 0);
    IQueryable<Product> GetProductsByCategory(int catID);
}
