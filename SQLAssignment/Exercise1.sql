----------------------------------------------------------EXERCISE 1-----------------------------------------------------------

--1. Display the number of records in the [SalesPerson] table. (Schema(s) involved: Sales)



SELECT COUNT(1)
FROM 
Sales.SalesPerson;



--2. Select both the FirstName and LastName of records from the Person table where the FirstName begins with the letter ‘B’. (Schema(s) involved: Person)

SELECT FirstName,LastName 
FROM 
Person.Person 
WHERE FirstName LIKE 'B%';



--3.Select a list of FirstName and LastName for employees where Title is one of Design Engineer, Tool Designer or Marketing Assistant. 
-- (Schema(s) involved: HumanResources, Person) 

SELECT Per.FirstName,Per.LastName
FROM 
Person.Person AS Per
INNER JOIN 
HumanResources.Employee AS Emp
ON Per.BusinessEntityID = Emp.BusinessEntityID 
WHERE Emp.JobTitle IN ('Design Engineer','Tool Designer','Marketing Assistant');




--4. Display the Name and Color of the Product with the maximum weight. (Schema(s) involved: Production) 

SELECT Name,Color 
FROM 
Production.Product 
WHERE 
Weight = (SELECT TOP 1 weight FROM Production.Product order by weight desc );




--5. Display Description and MaxQty fields from the SpecialOffer table. Some of the MaxQty values are NULL, in this case display the value 
--   0.00 instead. (Schema(s) involved: Sales)

SELECT Description,ISNULL(MaxQty,0.00)
FROM
Sales.SpecialOffer;




--6. Display the overall Average of the [CurrencyRate].[AverageRate] values for the exchange rate ‘USD’ to ‘GBP’ for the year 2005 i.e. 
--   FromCurrencyCode = ‘USD’ and ToCurrencyCode = ‘GBP’. Note: The field [CurrencyRate].[AverageRate] is defined as 'Average exchange 
--   rate for the day.' (Schema(s) involved: Sales)


select AVG(AverageRate)as 'Average exchange rate for the day' from Sales.CurrencyRate where
FromCurrencyCode='USD' AND ToCurrencyCode='GBP' AND YEAR(CurrencyRateDate)=2005;




--7. Display the FirstName and LastName of records from the Person table where FirstName contains the letters ‘ss’. Display an additional 
--   column with sequential numbers for each row returned beginning at integer 1. (Schema(s) involved: Person) 

SELECT ROW_NUMBER() OVER(ORDER BY FirstName) AS 'ROWNO.', FirstName,LastName 
FROM 
Person.Person 
WHERE FirstName LIKE '%ss%';




--8. Sales people receive various commission rates that belong to 1 of 4 bands. (Schema(s) involved: Sales).
--   Display the [SalesPersonID] with an additional column entitled ‘Commission Band’ indicating the appropriate band as above.
 
SELECT BusinessEntityID AS SalesPersonID ,
CASE WHEN CommissionPct = 0.00 THEN 'Band 0'
WHEN CommissionPct >0.00 AND CommissionPct <=0.01 THEN 'Band 1'
WHEN CommissionPct >0.01 AND CommissionPct <= 0.015 THEN 'Band 2'
ELSE 'Band 3'
END 
AS [Commission Band]
FROM sales.salesPerson;




--9.  Display the managerial hierarchy from Ruth Ellerbrock (person type – EM) up to CEO Ken Sanchez. Hint: use [uspGetEmployeeManagers] 
--   (Schema(s) involved: [Person], [HumanResources]) 

Declare @ID int;
Select @ID = BusinessEntityID
From Person.Person
where FirstName='Ruth' and LastName ='Ellerbrock' and PersonType='EM'
Exec dbo.uspGetEmployeeManagers @BusinessEntityID=@ID;


--10. Display the ProductId of the product with the largest stock level. Hint: Use the Scalar-valued function [dbo]. [UfnGetStock]. (Schema(s) 
--    involved: Production)


Select MAX(dbo.ufnGetStock(ProductID)) from Production.Product;
 