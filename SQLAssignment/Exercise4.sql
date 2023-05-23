--------------------------------------------------EXERCISE 4------------------------------------------------------------


--Create a function that takes as inputs a SalesOrderID, a Currency Code, and a date, and returns a table of all the SalesOrderDetail rows for that Sales 
--Order including Quantity, ProductID, UnitPrice, and the unit price converted to the target currency based on the end of day rate for the date 
--provided. Exchange rates can be found in the Sales.CurrencyRate table.

CREATE FUNCTION ufnSalesOrdersDetail(@SalesOrderID int,@CurrencyCode nchar(3),@Date datetime)
Returns Table
AS
Return
	SELECT sod.OrderQty AS QUANTITY , 
		   sod.ProductID,
		   sod.UnitPrice,
		   sod.UnitPrice*cr.EndOfDayRate AS 'OVERALL PRICE'
	FROM 
		Sales.CurrencyRate AS cr,
		Sales.SalesOrderDetail AS sod
	WHERE
		sod.SalesOrderID=@SalesOrderId AND 
		cr.ToCurrencyCode = @CurrencyCode AND
		cr.ModifiedDate = @Date  
GO

	
SELECT * from  ufnSalesOrdersDetail(43659,'GBP','2005-07-01');
