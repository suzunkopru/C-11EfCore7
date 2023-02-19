using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.DTOs;
using Entities.Models;
namespace Business.Classes;
public class ServiceDtoProductCatName
             : Service<Product>, IServiceDtoProductCatName
{
    private readonly IDalDtoProductCatName prodCatName;
    public ServiceDtoProductCatName(IEntityRepo<Product> p_entityRepo,
        IDalDtoProductCatName p_prodCatName) : base(p_entityRepo)
                                => prodCatName = p_prodCatName;
    public IQueryable<Product> GetProductsByCategory(int catID)
     => prodCatName.GetProductsByCategory(catID);

    public IQueryable<DtoProductCatName> GetProductsCatName()
                    => prodCatName.GetProductsCatName();

    public IQueryable<DtoProductCatName> GetProductsCatName(int id = 0)
                    => prodCatName.GetProductsCatName(0);
}
