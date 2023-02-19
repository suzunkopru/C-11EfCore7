using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceOrder : Service<Order>, IServiceOrder
{
    public ServiceOrder(IEntityRepo<Order> p_entityRepo)
                                        : base(p_entityRepo) { }
}

