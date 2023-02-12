using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalShipper : EntityRepo<Shipper>, IDalShipper
{
    public DalShipper(NorthwindContext p_context)
                                : base(p_context) { }
}

