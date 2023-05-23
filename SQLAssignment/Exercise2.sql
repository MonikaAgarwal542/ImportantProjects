----------------------------------------------------EXERCISE 2-------------------------------------------------------

--Write separate queries using a join, a subquery, a CTE, and then an EXISTS to list all AdventureWorks customers who have not placed an order.
  
------Using Join ------

SELECT *
FROM
	Sales.Customer c
LEFT OUTER JOIN 
	Sales.SalesOrderHeader s ON c.CustomerID = s.CustomerID
WHERE 
	s.SalesOrderID IS NULL ;



------Using SubQuery ------

SELECT *
FROM 
	Sales.Customer c
WHERE 
	c.CustomerID NOT IN(SELECT CustomerID FROM Sales.SalesOrderHeader);
					
	
	

------Using EXISTS---------

SELECT *
FROM Sales.Customer c
where NOT EXISTS(
SELECT *
FROM Sales.SalesOrderHeader s
WHERE s.customerID=c.CustomerID);




--------Using CTE(Common Table Expression)-------

WITH cte AS ( SELECT c.CustomerID,s.AccountNumber,s.ModifiedDate
			FROM
			Sales.Customer c
			LEFT OUTER JOIN 
			Sales.SalesOrderHeader s ON c.CustomerID = s.CustomerID
			WHERE 
			s.SalesOrderID IS NULL )

SELECT CustomerID
FROM
cte;


