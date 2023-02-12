using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalRegion : EntityRepo<Region>, IDalRegion
{
    public DalRegion(NorthwindContext p_context)
                                : base(p_context) { }
}

