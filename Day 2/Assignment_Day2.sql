-- ### Assignments Day 2 ###

-- Assignment 7
-- Create a trigger to updates the Stock (quantity) table whenever new order placed in orders tables
use BikeStores;
CREATE TRIGGER UpdateStockOnOrder
ON sales.order_items
AFTER INSERT 
AS 
BEGIN 
UPDATE s
set s.quantity = s.quantity -i.quantity
from production.stocks s
Inner join inserted i 
ON s.product_id = i.product_id
Inner join sales.orders o 
ON o.order_id = i.order_id
WHERE s.store_id = o.store_id;
END;

INSERT INTO sales.orders (customer_id, order_status, order_date, required_date, shipped_date, store_id, staff_id)
VALUES (1, 2, GETDATE(), GETDATE() + 5, NULL, 1, 2);

INSERT INTO sales.order_items (order_id, item_id, product_id, quantity, list_price, discount)
VALUES (1, 6, 10, 5, 100.00, 0.10);

-- Assignment 8
-- Create a trigger to that prevents deletion of a customer if they have existing orders.
CREATE TRIGGER PreventDeletion
on sales.customers 
INSTEAD OF DELETE
AS
BEGIN

IF EXISTS(
SELECT 1
FROM deleted D
inner join sales.orders o 
ON d.customer_id = o.customer_id
)
BEGIN 
Raiserror('Cannot delete customer. The customer has some orders left',16,1);
rollback transaction;
END

ELSE
BEGIN 
DELETE FROM sales.customers
WHERE customer_id IN(SELECT customer_id from deleted);
END

END;

delete from sales.customers where customer_id=1;
 
-- Assignment 9
-- a) Create Employee,Employee_Audit  insert some test data
CREATE TABLE Employee (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100),
    DeptId INT
);

INSERT INTO Employee(Name,DeptId)
VALUES 
('Happy Singh',1),
('Jocker Popat',2),
('Honey Bunny',1);

CREATE TABLE Employee_Audit (
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT,
    Operation VARCHAR(10),
    Name VARCHAR(100),
    DeptId INT,
    ChangeDate DATETIME DEFAULT GETDATE()
);

-- b) Create a Trigger that logs changes to the Employee Table into an Employee_Audit Table
CREATE TRIGGER tgr_EmployeeAudit
ON Employee
AFTER INSERT,UPDATE, DELETE
AS
BEGIN

-- Insert operation 
IF EXISTS (SELECT * FROM inserted)
BEGIN
INSERT INTO Employee_Audit(EmployeeID,Operation,Name,DeptId,ChangeDate)
SELECT EmployeeID,'INSERT',Name,DeptId,GETDATE() from inserted;
END

-- Delete operation
IF EXISTS (SELECT * FROM deleted)
BEGIN 
INSERT INTO Employee_Audit(EmployeeID,Operation,Name,DeptId,ChangeDate)
SELECT EmployeeID,'DELETE',Name,DeptId,GETDATE() from deleted;
END;

-- Update opration 
IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
BEGIN 
INSERT INTO Employee_Audit(EmployeeID,Operation,Name,DeptId,ChangeDate)
SELECT EmployeeID,'UPDATE',Name,DeptId,GETDATE() from inserted;
END;

END

-- Test trigger
INSERT INTO Employee(Name,DeptId)
VALUES ('Popat Lal',1);

UPDATE Employee set DeptId=3 where EmployeeID=1;

DELETE FROM Employee where EmployeeID=2;

-- Show logs
select * from Employee_Audit;

/*10) create Room Table with below columns
RoomID,RoomType,Availability
create Bookins Table with below columns
BookingID,RoomID,CustomerName,CheckInDate,CheckInDate
 
Insert some test data with both  the tables
Ensure both the tables are having Entity relationship
Write a transaction that books a room for a customer, ensuring the room is marked as unavailable.
*/

CREATE TABLE Room(
RoomID INT IDENTITY(1,1) PRIMARY KEY,
RoomType VARCHAR(50),
Availability BIT);

INSERT INTO Room (RoomType,Availability)
VALUES ('Single',1),('Double',1),('Suite',1);

CREATE TABLE Bookings(
BookingID INT IDENTITY(1,1) PRIMARY KEY,
RoomID int,
CustomerName varchar(100),
CheckInDate DATE,
CheckOutDate DATE,
FOREIGN KEY(RoomID) REFERENCES Room(RoomID)
);

INSERT INTO Bookings (RoomID,CustomerName,CheckInDate,CheckOutDate)
VALUES 
(1,'Micky Mouse','2024-11-01', '2024-11-05'),
(2, 'Doremon Nobita', '2024-11-10', '2024-11-15');

select * from Room
select * from Bookings

BEGIN TRANSACTION
DECLARE @RoomID int =3,
		@CustomerName varchar(100)='Spider Man',
		@CheckInDate DATE='2024-11-20',
		@CheckOutDate DATE = '2024-11-25';

IF EXISTS(SELECT 1 FROM Room where RoomID = @RoomID and Availability=1)
BEGIN 

INSERT INTO Bookings(RoomID,CustomerName,CheckInDate,CheckOutDate)
VAlues (@RoomID,@CustomerName,@CheckInDate,@CheckOutDate);

UPDATE Room 
SET Availability=0
where RoomID=@RoomID;

COMMIT TRANSACTION;
PRINT 'Room successfully booked and marked as unavailable for the guests';
END

ELSE
BEGIN
ROLLBACK TRANSACTION;
PRINT 'Room is not available for booking';
END


