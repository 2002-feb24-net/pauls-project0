CREATE TABLE Stores (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Location NVARCHAR(50) NOT NULL,
	Reviews INT NULL
);

CREATE TABLE Customers (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(50) NULL,
	PhoneNumber INT NOT NULL,
	FavoriteStoreId INT NULL FOREIGN KEY REFERENCES Stores(Id),
	FavoriteItem NVARCHAR(20) NULL,
);

CREATE TABLE Reviews (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	StoreId INT NOT NULL FOREIGN KEY REFERENCES Stores(Id),
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
	Score INT NOT NULL,
	text NVARCHAR(280) NULL,
);

INSERT INTO Stores (Location) VALUES
('Leominster'),
('Gardner'),
('Worcester');

CREATE TABLE OrderHistory (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	CustomerName NVARCHAR(50) NOT NULL,
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
	"Location" NVARCHAR(50) NOT NULL, 
	StoreId INT NOT NULL FOREIGN KEY REFERENCES Stores(Id),
	"Order" NVARCHAR(100) NOT NULL,
	"DateTime" SMALLDATETIME NOT NULL,
);


CREATE TABLE Inventory2 (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Product NVARCHAR(50) NOT NULL,
	Price MONEY NULL,
	LeominsterQuantity INT NOT NULL,
	GardnerQuantity INT NOT NULL,
	WorcesterQuantity INT NOT NULL,
);

INSERT INTO Inventory2 (Product, Price, LeominsterQuantity, GardnerQuantity, WorcesterQuantity ) VALUES
('Hamburgers', $3, 100, 100, 100),
('Buns', $1, 100, 100, 100),
('Cheese', $.50, 100, 100, 100),
('Bacon', $1, 100, 100, 100),
('Lettuce', $0, 100, 100, 100),
('Onions', $0, 100, 100, 100),
('Pickles', $0, 100, 100, 100),
('Mayonaise', $0, 100, 100, 100),
('Ketchup', $0, 100, 100, 100),
('Mustard', $0, 100, 100, 100),
('EdSauce', $.50, 100, 100, 100),
('Fries', $1, 100, 100, 100),
('Cola', $1, 100, 100, 100)
;

INSERT INTO Customers (FirstName, LastName, Address, PhoneNumber ) VALUES
('Heidi', 'Ewing', '1000 Concord ln, Marlboro, MA, 01520', 5085552290),
('Daniel', 'Mendoza', '58 Kilbourne dr, S. Lancaster, MA, 01561', 5085557390)
;

ALTER TABLE OrderHistory ADD 
TotalPrice MONEY NULL
;
UPDATE customers SET PhoneNumber =  5085555364
WHERE Id = 4;

UPDATE OrderHistory SET StoreId =  2
WHERE Location = 'Gardner';

INSERT INTO reviews (StoreID, CustomerId, Score, text) VALUES
(1, 1, 8.5, 'My favorite location. Best Eds Sauce'),
(2, 1, 6, 'Decent. Burger was kinda lukewarm, though'),
(3, 1, 1, 'Bad. Burger was cold, fries were stale, and the cola tasted like seltzer. Get it together, guys!')
;

Insert into orderhistory ( CustomerName, customerid, "location", storeid, "order", "datetime" ) values
((select firstname + ' ' + lastname from customers where Id = 3), 3, 'Leominster', 2, 'Good Cheeseburger Deluxe', current_timestamp),
((select firstname + ' ' + lastname from customers where Id = 4), 4, 'Worcester', 3, 'Double Cheeseburger Deluxe Meal', current_timestamp);

ALTER TABLE Stores ADD 
AvgReviewScore decimal(3,1) NULL

UPDATE stores SET Reviews = (select COUNT(*) from reviews where storeid = stores.id)
where id = 3

UPDATE stores SET avgreviewscore = (select AVG(score) from reviews where storeid = stores.id)
where id = 3

select * from customers
select * from reviews
select * from orderhistory
select * from stores
select * from inventory
select * from Prices

CREATE TABLE Prices (
	Product NVARCHAR(50) NOT NULL,
	Prices MONEY NULL
);

TRUNCATE TABLE OrderHistory;

INSERT INTO Prices (Product, Prices) VALUES
('Hamburgers', $3),
('Buns', $1),
('Cheese', $.50),
('Bacon', $1),
('Lettuce', $0),
('Onions', $0),
('Pickles', $0),
('Mayonaise', $0),
('Ketchup', $0),
('Mustard', $0),
('EdSauce', $.50),
('Fries', $1),
('Cola', $1)
;

DELETE FROM CUSTOMERS 
WHERE ID = 8

CREATE TABLE Inventory (
	StoreId INT NOT NULL PRIMARY KEY IDENTITY FOREIGN KEY REFERENCES Stores(Id),
	Location NVARCHAR(50),
	Hamburgers Int NOT NUll,
	Buns INT NOT NULL,
	Cheese INT NOT NULL,
	Bacon INT NOT NULL,
	Lettuce INT NOT NULL,
	Tomatoes INT NOT NULL,
	Onions INT NOT NULL,
	Pickles INT NOT NULL,
	Mayonaise INT NOT NULL,
	Ketchup INT NOT NULL,
	Mustard INT NOT NULL,
	EdSauce INT NOT NULL,
	Fries INT NOT NULL,
	Cola INT NOT NULL,
);

INSERT INTO Inventory (Location, Hamburgers, buns, cheese, bacon, lettuce, tomatoes, 
onions, pickles, mayonaise, ketchup, mustard, edsauce, fries, cola) VALUES
('Prices', 3, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1),
('Leominster', 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100)

UPDATE orderhistory SET Totalprice = 4
where OrderId = 2




select * from dbo

select * from customers

select * from reviews

select * from orderhistory

select * from stores

select * from inventory

select * from Prices

