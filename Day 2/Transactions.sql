-- Transactions 
use BikeStores;
BEGIN TRANSACTION
INSERT INTO sales.orders(customer_id,order_status,
order_date,required_date,shipped_date,store_id,staff_id)
VALUES(49,4,'20170228','20170301','20170302',2,6);

INSERT INTO sales.order_items(order_id,item_id,
product_id,quantity,list_price,discount)
VALUES(93,12,8,2,269.99,0.07);

IF @@ERROR=0
BEGIN
COMMIT TRANSACTION
PRINT 'Insertion Successful!...'
END
ELSE
BEGIN 
ROLLBACK TRANSACTION 
PRINT 'Something went wrong while insertion'
END

select * from sales.order_items

-- Example 2
Create database Transaction_demo_db;
use Transaction_demo_db;

CREATE TABLE CUSTOMERS
(customer_id int primary key,
Name varchar(100),
Active bit)

CREATE TABLE orders
(order_id int primary key,
customer_id int foreign key references Customers(customer_id),
order_status varchar(100)
)

INSERT INTO CUSTOMERS VALUES 
(1,'RAM',1),
(2,'SHYAM',1)

INSERT INTO orders VALUES 
(101,1,'Pending'),
(102,2,'Pending')

select * from CUSTOMERS
select * from orders

-- Transaction A

BEGIN TRANSACTION
UPDATE CUSTOMERS SET NAME='John'
WHERE customer_id=1

WAITFOR DELAY '00:00:05';
UPDATE orders SET order_status='Processed'
WHERE order_id=101

COMMIT TRANSACTION 

-- Transaction B

BEGIN TRANSACTION
UPDATE orders SET order_status='Shipped'
WHERE order_id=101

WAITFOR DELAY '00:00:05';
UPDATE CUSTOMERS SET NAME='Vivek'
WHERE customer_id=1

COMMIT TRANSACTION 