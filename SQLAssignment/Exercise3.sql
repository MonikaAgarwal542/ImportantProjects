-----------------------------------------------EXERCISE 3-------------------------------------------------------------
--Show the most recent five orders that were purchased from account numbers that have spent more than $70,000 with AdventureWorks.


SELECT  TOP(5) 
	salesOrderId AS 'ORDER ID',
	CustomerID AS 'CUSTOMER ID',
	OrderDate AS'ORDER DATE',
	AccountNumber AS 'ACCOUNT NUMBER'
FROM 
	Sales.SalesOrderHeader 
WHERE
	 AccountNumber IN
    (Select AccountNumber from Sales.SalesOrderHeader group by AccountNumber Having SUM(SubTotal)>70000)
ORDER BY
	OrderDate DESC;

