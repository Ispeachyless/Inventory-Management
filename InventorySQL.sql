create database FPROJECT;

use FPROJECT;

-- Employee

create table employee
(
empID bigint primary key,
username varchar(50) default '',
pass varchar(50),
)

create table eContacts
(
empID bigint,
fName varchar(50) default '',
lName varchar(50) default '',
phone char(11)
constraint fk_empId foreign key (empID)
references employee(empID) on update cascade
)

insert into employee values(1000, 'admin', '1234')
insert into employee values(1001, 'cookie', 'idk')
insert into employee values(1002, 'kate', 'password')

insert into eContacts values(1000, 'Ralph', 'Agang', '09009909090')
insert into eContacts values(1001, 'Althea', 'Monteverde', '09090909090')
insert into eContacts values(1002, 'Kate', 'Lopez', '09090909091')

--Contacts

create table CContacts
(
  CusID bigint unique not null, 
  FName varchar(50),
  Lname varchar(50),
  phone bigint,
)

insert into CContacts values(2001, 'Kenji','Isuga', 09090909179)
insert into CContacts values(2002, 'Thea','Salvador', 09090909179)
insert into CContacts values(2003, 'Sheena','Rebalde', 09090909179)

--Sales

create table sales(
iDate date,
orderID int,
invoiceNo int,
cusID int,
iStatus varchar(50),
dDate date
)	

create table salesDetails(
invoiceNo int,
ItemID bigint,
Qty int default 1,
PDetailsID int
)
insert into sales values(getdate(), 3001, 4001, 2001,'Order Placed', getdate())
insert into sales values(getdate(), 3002, 4002, 2002,'Order Placed',  getdate())
insert into sales values(getdate(), 3003, 4003, 2002,'Order Placed',  getdate())

insert into salesDetails values (4001, 5001, 3, 6001)
insert into salesDetails values (4001, 5003, 1, 6001)
insert into salesDetails values (4002, 5005, 2, 6001)

--Items

Create table Item
(
  ItemID bigint unique not null,
  IName varchar(50),
  IDes varchar(255),
  UnitPrice int,
)

insert into Item values(5001, 'Towel Rack','', 200)
insert into Item values(5002, 'Foldable Chair','', 230)
insert into Item values(5003, 'Side Table','', 150)

-- Production and Production Details

CREATE TABLE Production (
	ProductionID BIGINT,
	ArrivalDate DATE
);

CREATE TABLE ProductionDetails (
  PDetailsID BIGINT,
  ProductionID BIGINT,
  ItemID BIGINT,
  PStatus varchar(50) DEFAULT 'On hand',
  Quantity INT DEFAULT 1,

);

INSERT INTO Production (ProductionID , ArrivalDate) 
VALUES
(1, getdate()),
(2, getdate());

INSERT INTO ProductionDetails (PDetailsID, ProductionID, ItemID, Quantity) VALUES
(6000, 1, 5001, 50),
(6001, 1, 5002, 50),
(6002, 2, 5003, 50);

-- Return Sales

create table ReturnCustomer(
RID bigint,
invoiceNo bigint,
ItemID bigint,
cusID bigint,
Reason varchar(50),
RStatus varchar (50),
)

insert into ReturnCustomer values(7000, '4000', '5001', '2000', 'Change of Mind', ' Requested')
insert into ReturnCustomer values(7001, '4001', '5002', '2001', 'Delivery Delay', ' Requested')
insert into ReturnCustomer values(7002, '4002', '5003', '2002', 'Delivery Delay', ' Requested')


  
