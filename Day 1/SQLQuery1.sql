
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

-- TRY 2
CREATE PROCEDURE uspGetCustomersByProductNew
    @ProductID INT
AS
BEGIN
    SELECT 
        customers.customer_id AS CustomerID,
        customers.first_name AS FirstName,
        customers.last_name AS LastName,
        orders.order_date AS PurchaseDate
    FROM 
        sales.customers AS customers, 
        sales.orders AS orders, 
        sales.order_items AS order_items
    WHERE 
        customers.customer_id = orders.customer_id
        AND orders.order_id = order_items.order_id
        AND order_items.product_id = @ProductID;
END;

execute uspGetCustomersByProductNew @ProductID =20;
