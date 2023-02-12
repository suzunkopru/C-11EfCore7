using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalTerritory : EntityRepo<Territory>, IDalTerritory
{
    public DalTerritory(NorthwindContext p_context)
                                : base(p_context) { }
}

