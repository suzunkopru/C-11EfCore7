using DataAccess.Interfaces;
using Entities.Context;
using Entities.Models;
namespace DataAccess.Classes;
public class DalProduct : EntityRepo<Product>, IDalProduct
{
    public DalProduct(NorthwindContext p_context)
                            : base(p_context) { }
}