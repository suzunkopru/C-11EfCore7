using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Models;
namespace Business.Classes;
public class ServiceCustomer : Service<Customer>, IServiceCustomer
{
    public ServiceCustomer(IEntityRepo<Customer> p_entityRepo)
                                        : base(p_entityRepo) { }
}

