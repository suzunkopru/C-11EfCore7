using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalEmployee : EntityRepo<Employee>, IDalEmployee
{
    public DalEmployee(NorthwindContext p_context)
                                : base(p_context) { }
}

