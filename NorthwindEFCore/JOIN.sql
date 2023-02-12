Select ProductID, ProductName, CategoryID, UnitsInStock
From 
Products
Select CategoryID, CategoryName
From 
Categories

Select pr.ProductID, pr.ProductName, cr.CategoryName, pr.UnitsInStock
From Products pr Join Categories cr
On pr.CategoryID = cr.CategoryID

SELECT [p].[ProductID], [p].[ProductName], [c].[CategoryName], [p].[UnitsInStock]
FROM [Products] AS [p]
INNER JOIN [Categories] AS [c] ON [p].[CategoryID] = [c].[CategoryID]