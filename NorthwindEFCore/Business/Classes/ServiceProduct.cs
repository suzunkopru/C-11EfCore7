using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceProduct : Service<Product>, IServiceProduct
{
    public ServiceProduct(IEntityRepo<Product> p_entityRepo)
                                        : base(p_entityRepo) { }
}