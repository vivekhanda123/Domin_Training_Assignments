
-- Example 1
Create PROCEDURE useDisplayMessage
AS
BEGIN 
PRINT 'Welcome to The training'
END;

EXECUTE useDisplayMessage

-- Example 2

SELECT * FROM production.products;

CREATE proc uspProductList
AS
BEGIN
select Product_name,list_price from production.products
order by product_name
END

drop procedure uspProductList

exec uspProductList

sp_help uspProductList

-- Alter procedure

ALTER PROC uspProductList
AS
BEGIN 
select Product_name,model_year, list_price from 
production.products order by list_price desc
END

-- To Show
uspProductList

exec sp_rename 'uspProductList' , 'uspMyProductList'

-- Parameter is stored procedure
--input and output parameter

CREATE PROC uspFindProducts (@modelyear as int)
AS
Begin 
SELECT * FROM production.products where model_year = @modelyear
END

--Ex4
-- using named parameters 
create proc uspFindProductsByName
(@minPrice as decimal = 2000,@maxPrice decimal, @name as varchar(max))
AS
BEGIN
select * from production.products where list_price>=@minPrice and list_price<=@maxPrice
and 
product_name like '%'+@name+'%'
END

uspFindProductsByName 100,1000,'Sun'

--uspFindProductsByName @max incomplete

-- Optional parameter
ALTER PROC uspFindProductsByName
(@minPrice as decimal = 2000, @maxPrice decimal, @name as varchar(max))
AS
BEGIN
select * from production.products where list_price>=@maxPrice and 
list_price<=@maxPrice
and 
product_name like '%'+@name+'%'
END

uspFindProductsByName 100,1000,'Sun'
uspFindProductsByName @maxPrice = 3000, @name = 'Trek'

-- Out parameter
CREATE PROCEDURE uspFindProductCountByModelYear
(@modelyear int,
@productCount int OUTPUT)
AS
BEGIN
select Product_name, list_Price
from production.products
WHERE 
model_year = @modelyear

select @productCount = @@ROWCOUNT
END

DECLARE @count int;
EXEC uspFindProductCountByModelYear @modelyear = 2016,@productCount = @count OUT;
select @count as 'Number of Products Found'

-- Can one stored procedure call another stored procedure 

CREATE PROC usp_GetAllCustomers
AS
BEGIN
select * from sales.customers
END

usp_GetAllCustomers


CREATE PROC usp_getCustomerOrders
@customerId int 
AS
BEGIN
select * from sales.orders
WHERE 
customer_id = @customerId
END

usp_getCustomerOrders 1

-- to call one into another
ALTER PROC usp_GetCustomerData
@customerId int 
AS 
BEGIN
EXEC usp_GetAllCustomers;
EXEC usp_getCustomerOrders @customerId;
END

exec usp_GetCustomerData 1

-- Assignment 1
/* You need to create a stored procedure that retrieves a list of all customers who have purchased a specific product.
consider below tables Customers, Orders,Order_items and Products
Create a stored procedure,it should return a list of all customers who have purchased the specified product, 
including customer details like CustomerID, CustomerName, and PurchaseDate.
The procedure should take a ProductID as an input parameter.
*/

CREATE PROCEDURE GetCustomersByProduct
@ProductID INT  
AS
BEGIN
select C.customer_id AS CustomerID,       
CONCAT(C.first_name, ' ', C.last_name) AS CustomerName,  
O.order_date AS PurchaseDate       
from  
sales.customers C                  
INNER JOIN 
sales.orders O 
ON C.customer_id = O.customer_id  
INNER JOIN 
sales.order_items OI 
ON O.order_id = OI.order_id 
INNER JOIN 
production.products P 
ON OI.product_id = P.product_id  
WHERE 
OI.product_id = @ProductID          
order by 
O.order_date;                     
END;

EXEC GetCustomersByProduct 101;

-- Assignment 2
/*
CREATE TABLE Department with the below columns
  ID,Name
populate with test data
 
 
CREATE TABLE Employee with the below columns
  ID,Name,Gender,DOB,DeptId
populate with test data
 
a) Create a procedure to update the Employee details in the Employee table based on the Employee id.
b) Create a Procedure to get the employee information bypassing the employee gender and department id from the Employee table
c) Create a Procedure to get the Count of Employee based on Gender(input)
*/

-- Table Department
CREATE TABLE Department (
ID int PRIMARY KEY,
Name varchar(100) NOT NULL 
);

-- Adding data into Department
INSERT INTO Department(ID,Name) 
VALUES 
(1,'Testing'),
(2,'Development'),
(3,'HR'),
(4,'Finance');

-- Employee table
CREATE TABLE Employee (
ID int PRIMARY KEY,
Name varchar(100) not null,
Gender char(1) not null,
DOB DATE not null,
DeptId int,
FOREIGN KEY (DeptId) REFERENCES Department(ID)
);

-- Inserting values into Employee
INSERT INTO Employee (ID, Name, Gender, DOB, DeptId) 
VALUES 
(1, 'Shivam Katiyar', 'M', '2002-05-10', 1),
(2, 'Satyam Katiyar', 'M', '2002-11-22', 1),
(3, 'Akshay Chauhan', 'M', '2002-03-15', 3),
(4, 'Aditya Chauhan', 'M', '2002-08-30', 4);

-- Show the table 
select * from Department;
select * from Employee;

-- Creating a procedure
CREATE PROCEDURE UpdateEmployeeDetails
@EmployeeID int,
@Name varchar(100),
@Gender char(1),
@DOB DATE,
@DeptId int
AS
BEGIN
UPDATE Employee
SET 
Name = @Name,
Gender = @Gender,
DOB = @DOB,
DeptId = @DeptId
WHERE ID = @EmployeeID;
END;

EXEC UpdateEmployeeDetails 1,'Tanmay Chocksey','M','1995-02-02',1;
select * from Employee;

-- Second procedure
CREATE PROCEDURE GetEmployeeByGenderAndDept
@Gender char(1),
@DeptId int
AS
BEGIN
select 
e.ID AS EmployeeID,
e.Name AS EmployeeName,
e.Gender,
e.DOB,
d.Name AS DepartmentName
FROM Employee e
INNER JOIN 
Department d 
ON e.DeptId = d.Id
Where   
e.Gender = @Gender
AND e.DeptId = @DeptId;
END;

EXEC GetEmployeeByGenderAndDept 'M',1


--Third procedure
CREATE PROCEDURE GetEmployeeCountByGender
@Gender char(1)
AS 
BEGIN
select count(*) AS EmployeeCount
from Employee
where Gender = @Gender;
END;

EXEC GetEmployeeCountByGender 'M'; -- try this with output parameter