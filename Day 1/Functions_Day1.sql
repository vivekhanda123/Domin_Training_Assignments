--  User defined function 

Create Function GetAllProducts()
RETURNS INT
AS
BEGIN
RETURN (SELECT COUNT(*) from production.products)
END

PRINT dbo.GetAllProducts() 

-- Table Valued Function 
-- Inline table valued function => Contain single select statement

Create function GetProductById (@productId int)
RETURNS Table 
AS 
RETURN (select * from production.products where product_id = @productId);

select * from GetProductById(4)


-- Example 2 
CREATE FUNCTION ILTVF_GetEmployees()
RETURNS TABLE 
AS 
RETURN (SELECT Id, Name, CAST(DOB as Date) as DOB from Employee)

--Multi statement table valued function 
CREATE FUNCTION MSTVF_GetEmployee()
RETURNS @TempTable Table(Id int, Name varchar(100),DOB Date)
AS
BEGIN 
INSERT INTO @TempTable
SELECT Id,Name, CAST(DOB as Date) from Employee
Return 
END

select * from Employee;
select * from MSTVF_GetEmployee()

select * from ILTVF_GetEmployees();

update ILTVF_GetEmployees() SET Name = 'Vivek' where Id = 1
update MSTVF_GetEmployee() SET Name = 'Tina' where Id = 2 -- cannot update because its taking data from temp table  


-- Assignment 3 
-- Create a user Defined function to calculate the TotalPrice based on productid and Quantity Products Table

CREATE FUNCTION CalculateTotalPrice(@ProductID int, @Quantity int)
RETURNS DECIMAL(10,2)
AS 
BEGIN 
DECLARE @TotalPrice DECIMAL(10,2);
SELECT @TotalPrice = (p.list_price * @Quantity)
FROM production.products p
WHERE p.product_id = @ProductID;
RETURN @TotalPrice;
END;

select dbo.CalculateTotalPrice(1,5) AS TotalPrice;

-- Assignment 4
-- Create a function that returns all orders for a specific customer, including details such as OrderID, OrderDate, and the total amount of each order.

CREATE FUNCTION GetCustomerOrders(@CustomerID int)
RETURNS TABLE 
AS 
RETURN (SELECT o.order_id as OrderID, o.order_date as OrderDate, SUM(OI.quantity * OI.list_price * (1 - OI.discount)) AS TotalAmount
FROM sales.orders o
INNER JOIN sales.order_items oi ON o.order_id=oi.order_id
where o.customer_id = @CustomerID
GROUP BY o.order_id, o.order_date
);

select * from dbo.GetCustomerOrders(1);

-- Assignment 5
-- Create a Multistatement table valued function that calculates the total sales for each product, considering quantity and price.

CREATE FUNCTION CalculateTotalSalesMultivalued()
RETURNS @TotalSalesTable TABLE(ProductID int, ProductName varchar(100), TotalSales decimal(18,2))
AS 
BEGIN 
insert into @TotalSalesTable(ProductID,ProductName,TotalSales)
select p.product_id as ProductID, p.product_name as ProductName, SUM(oi.quantity * oi.list_price) AS TotalSales
from production.products p
INNER JOIN sales.order_items oi 
ON p.product_id = oi.product_id
group by p.product_id, p.product_name;
return ;
END;

select * from dbo.CalculateTotalSalesMultivalued();

-- Assignment 6
-- Create a  multi-statement table-valued function that lists all customers along with the total amount they have spent on orders.

CREATE FUNCTION GetCustomerTotalSpentMultivalued()
RETURNS @CustomerSpending table (CustomerID int, CustomerName varchar(100),TotalAmountSpent decimal(18,2))
AS
BEGIN 
INSERT INTO @CustomerSpending(CustomerID,CustomerName,TotalAmountSpent)
select c.customer_id as CustomerID,CONCAT(c.first_name, ' ', c.last_name) AS CustomerName, SUM(oi.quantity * oi.list_price) AS TotalAmountSpent
from sales.customers c
LEFT JOIN sales.orders o 
ON c.customer_id = o.customer_id
LEFT JOIN sales.order_items oi 
ON o.order_id = oi.order_id 
group by c.customer_id,c.first_name,c.last_name;
RETURN;
END;

select * from dbo.GetCustomerTotalSpentMultivalued();