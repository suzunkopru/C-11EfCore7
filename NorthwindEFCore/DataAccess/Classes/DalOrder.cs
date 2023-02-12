using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalOrder : EntityRepo<Order>, IDalOrder
{
    public DalOrder(NorthwindContext p_context)
                                : base(p_context) { }
}

