---------------------------------------------- EXERCISE 5 ------------------------------------------------------------


--Write a Procedure supplying name information from the Person.Person table and accepting a filter for the first name. Alter the above Store 
--Procedure to supply Default Values if user does not enter any value.

CREATE PROCEDURE Name_Info
@Name varchar(20)
as 
BEGIN
	SELECT BusinessEntityID AS Id,FirstName,MiddleName,LastName from PERSON.PERSON
	WHERE FirstName=@Name;
END
 


ALTER PROCEDURE Name_Info 
  @Name varchar(20)
AS
IF @Name IS NULL BEGIN;
  SET @Name='Monika'
END;
SELECT FirstName,MiddleName,LastName from Person.Person WHERE FirstName=@Name;


 EXECUTE Name_Info null
 EXEC Name_Info 'Karen'

