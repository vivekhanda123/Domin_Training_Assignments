create database Hexa_Oct_22;
use Hexa_Oct_22;

CREATE TABLE Employee
(
Id INT,
Name varchar(50),
Salary int,
Gender varchar(50),
City varchar(50),
Dept varchar(50)
)

INSERT INTO Employee VALUES (3,'Pranav',4500,'Male','New York','IT')
INSERT INTO Employee VALUES (1,'Anurag',4500,'Female','London','IT')
INSERT INTO Employee VALUES (4,'Tanmay',4500,'Male','Tokio','HR')
INSERT INTO Employee VALUES (5,'Umang',4500,'Male','Toronto','HR')
INSERT INTO Employee VALUES (7,'Sambit',4500,'Female','Mumbai','IT')
INSERT INTO Employee VALUES (6,'Shobit',4500,'Male','Indore','IT')
INSERT INTO Employee VALUES (2,'Atharv',4500,'Female','Delhi','HR')
INSERT INTO Employee VALUES (8,'Mayank',4500,'Male','Chennai','IT')
INSERT INTO Employee VALUES (10,'Riya',4500,'Female','New York','IT')
INSERT INTO Employee VALUES (9,'Sara',4500,'Female','Shimla','HR')

select * from Employee where Id=8

CREATE INDEX IX_EMPLOYEE_ID
ON EMPLOYEE(ID ASC)

CREATE CLUSTERED INDEX IX_EMPLOYEE_ID1
ON EMPLOYEE (ID ASC)

create table Employee1
(
Id	int primary key,
Name varchar(50),
Salary int,
Gender varchar(50),
City varchar(50),
Dept varchar(50)
)

select * from Employee1

INSERT INTO Employee1 VALUES (3,'Pranav',4500,'Male','New York','IT')
INSERT INTO Employee1 VALUES (1,'Anurag',4500,'Female','London','IT')
INSERT INTO Employee1 VALUES (4,'Tanmay',4500,'Male','Tokio','HR')
INSERT INTO Employee1 VALUES (5,'Umang',4500,'Male','Toronto','HR')
INSERT INTO Employee1 VALUES (7,'Sambit',4500,'Female','Mumbai','IT')
INSERT INTO Employee1 VALUES (6,'Shobit',4500,'Male','Indore','IT')
INSERT INTO Employee1 VALUES (2,'Atharv',4500,'Female','Delhi','HR')
INSERT INTO Employee1 VALUES (8,'Mayank',4500,'Male','Chennai','IT')
INSERT INTO Employee1 VALUES (10,'Riya',4500,'Female','New York','IT')
INSERT INTO Employee1 VALUES (9,'Sara',4500,'Female','Shimla','HR')

-- BikeDB
SELECT * FROM sales.customers 

CREATE UNIQUE INDEX idx_unique_email
ON sales.customer(email)
-- Example for clustered index 
-- We can create only one clustered index per table 
-- If we have primary key in a table automatically it will create clustered index for that tabel 
-- suppose when table is not having primary key then only we can create clustered index 
-- If we create dulplicate and null values exist it will sort and store the data


CREATE CLUSTERED INDEX IX_EMPLOYEE_ID1
ON EMOPLOYEE(ID ASC)

-- NON CLUSTERED index
-- We can create upto 999 non clustered index per table 
CREATE NONCLUSTERED INDEX idx_name
ON sales.customers(first_name,last_name)
--(or)
CREATE INDEX idx_name1
ON sales.customers(first_name,last_name)


-- New example
Create table Department
(
Id int, 
Name varchar(100)
)

-- Inserting duplicate values as it will accept it 
insert into Department
values(1,'HR'),
(1,'Admin')

select * from Department

CREATE CLUSTERED INDEX idx_dept_id
ON Department(Id)

insert into Department values (2,'IT'),
(3,'Transport'),
(4,'Information Tech')

-- Inserting null value
insert into Department(Name) values ('Insurance')


-- Views creation 

CREATE TABLE tblEmployee
(
Id int Primary key,
Name nvarchar(30),
Salary int,
Gender nvarchar(10),
DepartmentId int
)
-- Sql script to create tblDepartment table 
CREATE TABLE tblDepartment
(
DeptId int primary key,
DeptName nvarchar(20)
)

--Insert data into table 
Insert into tblDepartment values (1,'IT')
Insert into tblDepartment values (2,'Payroll')
Insert into tblDepartment values (3,'HR')
Insert into tblDepartment values (4,'Admin')

-- Insert data into tblEmployee 
Insert into tblEmployee  values (1,'John',5000,'Male',3)
Insert into tblEmployee  values (2,'Mike',3400,'Male',2)
Insert into tblEmployee  values (3,'Pam',6000,'Female',1)
Insert into tblEmployee  values (4,'Todd',4800,'Male',4)
Insert into tblEmployee  values (5,'Sara',3200,'Female',1)
Insert into tblEmployee  values (6,'Ben',4800,'Male',3)

select * from tblEmployee

Select Id, Name, Salary, Gender, DeptName
from tblEmployee
join tblDepartment
on tblEmployee.DepartmentId = tblDepartment.DeptId

-- Now let's create a view using joins query 
Create view vWEmployeeByDepartment
as
select Id,Name,Salary,Gender, DeptName
from tblEmployee
join tblDepartment
on tblEmployee.DepartmentId = tblDepartment.DeptId


select * from vWEmployeeByDepartment
select * from tblEmployee
--Update the view value and original table value
update vWEmployeeByDepartment set Name='Vivek' where Id=3

insert into vWEmployeeByDepartment values(7,'Ron',9000,'Male','IT')

-- View that returns only it department employees 
Create view vWITDepartment_Employees
as
Select Id, Name, Salary, Gender, DeptName
from tblEmployee
join tblDepartment
on tblEmployee.DepartmentId = tblDepartment.DeptId
where tblDepartment.DeptName = 'IT'

select * from vWITDepartment_Employees

Create view vWEmployeeCountByDepartment
as
Select DeptName, COUNT(Id) as TotalEmployees
from tblEmployee
join tblDepartment
on tblEmployee.DepartmentId = tblDepartment.DeptId
Group By DeptName

select * from vWEmployeeCountByDepartment
sp_helptext vWEmployeeCountByDepartment


-- New Topic
-- Trigger 
CREATE TABLE orders
(
order_id int primary key,
customer_id int, 
order_date DATE
)

CREATE TABLE order_audit
(
audit_id int identity primary key,
order_id int, 
customer_id int,
order_date DATE,
audit_date DATETIME DEFAULT GETDATE()
);

ALTER TABLE Order_Audit ADD audit_information varchar(max)

--Example for After or for trigger with insert 
select * from orders
select * from order_audit

CREATE TRIGGER trgAfterInsertOrder
ON Orders
AFTER INSERT 
AS
BEGIN 
DECLARE @auditInfo nvarchar(1000)
SET @auditInfo = 'Data Inserted'
INSERT INTO order_audit(order_id,customer_id,order_date,audit_information)
SELECT order_id,customer_id, order_date,@auditInfo
FROM inserted
END

insert into orders values (1001,21,'03-10-2024')
insert into orders values (1002,31,'04-10-2024')

update orders set customer_id = 32 where order_id=1
update orders set customer_id = 31 where order_id=1001

--Example for After or For Trigger with update 

CREATE TRIGGER trgAfterUpdateOrder
ON Orders
FOR UPDATE
AS 
BEGIN
DECLARE @auditInfo nvarchar(1000)
SET @auditInfo = 'Data Changed'
INSERT INTO order_audit(order_id,customer_id,order_date,audit_information)
SELECT order_id,customer_id,order_date,@auditInfo
FROM inserted
END;

UPDATE orders SET customer_id=33,order_date='10-10-2020'
WHERE order_id=1001

UPDATE orders SET customer_id=31,order_date='10-10-2024'
WHERE order_id=1001

select * from tblDepartment;
select * from tblEmployee;

--Instead of Trigger

CREATE VIEW vwEmployeeDetails 
AS
SELECT Id,Name, Gender,DeptName from tblEmployee e
join tblDepartment d
on e.DepartmentId = d.DeptId

select * from vwEmployeeDetails

INSERT vwEmployeeDetails values (7,'Tina','Female','HR') -- it will give error because we cannot update it 

-- For this we create a trigger
CREATE TRIGGER tr_vwEmployeeDetails_InsteadOfInsert
ON vwEmployeeDetails
INSTEAD OF INSERT
AS
BEGIN 
DECLARE @deptId int 
SELECT @deptId=DeptId from tblDepartment
join inserted
ON inserted.DeptName = tblDepartment.DeptName

if(@deptId is null)
BEGIN 
Raiserror('Invalid Department Name. Statement Terminated',16,1)
return 
END
Insert into tblEmployee(Id,Name,Gender,DepartmentId)
select Id,Name,Gender,@deptId
FROM inserted 
END

INSERT vwEmployeeDetails values (7,'Mona','Female','HR')
INSERT vwEmployeeDetails values (8,'Yash','Male','Finance')






