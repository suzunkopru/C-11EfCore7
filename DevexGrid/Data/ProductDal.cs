namespace DevexGrid.Data;
public record ProductDal //Dikkat record (kayıt), class değil.
{
    List<Product> GetAll()
    {
        Product prd1 = new()
        {
            ProductID = 1,
            ProductName = "Prd1",
            SupplierID = 1,
            CategoryID = 1,
            QuantityPerUnit = "Adet",
            UnitPrice = 100,
            UnitsInStock = 25,
            UnitsOnOrder = 1,
            Discontinued = false
        };
        var prd2 = prd1 with
        {
            ProductID = 2,
            ProductName = "Prd2",
            UnitPrice = 99
        };
        var prd3 = prd2 with
        {
            ProductID = 3,
            ProductName = "Prd3",
            UnitPrice = 98
        };
        List<Product> products = new();
        products.AddRange(
            new List<Product> { prd1, prd2, prd3 });
        products.AddRange(products);
        return products;
    }
    public async Task<IEnumerable<Product>>
        ProductList(CancellationToken ct = default)
        => await Task.FromResult(GetAll());
}