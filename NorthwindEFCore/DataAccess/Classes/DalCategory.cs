using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalCategory : EntityRepo<Category>, IDalCategory
{
    public DalCategory(NorthwindContext p_context)
                                : base(p_context) { }
}

