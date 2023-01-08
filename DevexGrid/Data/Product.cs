namespace DevexGrid.Data;
public struct Product //Dikkat struct (yapı), class değil.
{
    public int ProductID { get; set; }  //SQL int
    public string ProductName { get; set; } //SQL nvarchar
    public int SupplierID { get; set; } 
    public int CategoryID { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; } //SQL money
    public int UnitsInStock { get; set; }
    public int UnitsOnOrder { get; set; }
    public bool Discontinued { get; set; } //SQL bit
}
