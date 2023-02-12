using DataAccess.Interfaces;
using Entities.Context;
using Entities.DTOs;
using Entities.Models;
namespace DataAccess.Classes;
public class DalDtoProductCatName
             : EntityRepo<Product>, IDalDtoProductCatName
{
   private readonly NorthwindContext _context;
    public DalDtoProductCatName(NorthwindContext p_context) 
         : base(p_context) => _context = p_context;
    public IQueryable<DtoProductCatName> GetProductsCatName()
         => _context.Products.Join(_context.Categories,
             pr => pr.CategoryId,
             ct => ct.CategoryId,
             (pr,ct) =>
             new DtoProductCatName 
             { 
                 ProductID = pr.ProductId,
                 ProductName = pr.ProductName,
                 CategoryName=ct.CategoryName,
                 UnitsInStock = pr.UnitsInStock
             });
    public IQueryable<DtoProductCatName> GetProductsCatName
        (int id=0)
     => from pr in _context.Products
        join ct in _context.Categories
        on pr.CategoryId equals ct.CategoryId
        select new DtoProductCatName
        {
            ProductID = pr.ProductId,
            ProductName = pr.ProductName,
            CategoryName = ct.CategoryName,
            UnitsInStock = pr.UnitsInStock
        };
    public IQueryable<Product> GetProductsByCategory
        (int catID) => Where(x => x.CategoryId == catID);
}
