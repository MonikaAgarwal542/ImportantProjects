--------------------------------------------EXERCISE 6-----------------------------------------------------


--Write a trigger for the Product table to ensure the list price can never be raised more than 15 Percent in a single change. Modify the above trigger 
--to execute its check code only if the ListPrice column is updated.


CREATE TRIGGER CHECKLISTPRICE
ON Production.Product
AFTER UPDATE
AS
	IF UPDATE(ListPrice)
	DECLARE @oldlistprice money
	DECLARE @newlistprice money
	SELECT @oldlistprice = ListPrice from deleted
	SELECT @newlistprice = ListPrice from inserted
	BEGIN
		UPDATE Production.Product
		SET ListPrice = IIF(@newlistprice-@oldlistprice > 0.15*@oldlistprice,@oldlistprice,@newlistprice)
		from deleted,Production.Product AS p
		INNER JOIN inserted ON inserted.ProductID = p.ProductID
END

UPDATE Production.Product
SET ListPrice = 200
WHERE ProductID = 1;

SELECT * FROM Production.Product;