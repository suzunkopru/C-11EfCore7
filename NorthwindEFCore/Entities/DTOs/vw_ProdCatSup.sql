Create or Alter View vw_ProdCatSup With Encryption
As
SELECT 
		p.ProductID, p.ProductName, p.UnitsInStock,
		c.CategoryName,
		s.CompanyName, s.Country 
FROM 
	Products AS p
INNER JOIN Categories AS c
	ON p.CategoryID = c.CategoryID
INNER JOIN Suppliers AS s
	ON p.SupplierID = s.SupplierID