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


CREATE TABLE Inventory (
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	Product NVARCHAR(50) NOT NULL,
	LeominsterQuantity INT NOT NULL,
	GardnerQuantity INT NOT NULL,
	WorcesterQuantity INT NOT NULL,
);

INSERT INTO Inventory (Product, LeominsterQuantity, GardnerQuantity, WorcesterQuantity ) VALUES
('Hamburgers', 100, 100, 100),
('Buns', 100, 100, 100),
('Cheese', 100, 100, 100),
('Lettuce', 100, 100, 100),
('Onions', 100, 100, 100),
('Pickles', 100, 100, 100),
('Mayonaise', 100, 100, 100),
('Ketchup', 100, 100, 100),
('Mustard', 100, 100, 100),
('EdSauce', 100, 100, 100),
('Fries', 100, 100, 100),
('Cola', 100, 100, 100)
;

INSERT INTO Customers (FirstName, LastName, Address, PhoneNumber ) VALUES
('Terrence', 'Ewing', '1000 Concord ln, Marlboro, MA, 01520', 5085557390);

ALTER TABLE Stores ADD 
PhoneNumber CHAR(10) NULL
;
UPDATE customers SET favoriteitem =  'Double Bacon Cheeseburger w/ketchup, mayo, edsauce '
WHERE Id = 1;

INSERT INTO reviews (StoreID, CustomerId, Score, text) VALUES
(1, 1, 8.5, 'My favorite location. Best Eds Sauce'),
(2, 1, 6, 'Decent. Burger was kinda lukewarm, though'),
(3, 1, 1, 'Bad. Burger was cold, fries were stale, and the cola tasted like seltzer. Get it together, guys!')
;

Insert into orderhistory (customername, customerid, "location", storeid, "order", "datetime" ) values
((select firstname + ' ' + lastname from customers), 1, 'Gardner', 1, 'Double Bacon Cheeseburger w/ketchup, mayo, edsauce',	current_timestamp);

ALTER TABLE Stores ADD 
AvgReviewScore decimal(3,1) NULL

UPDATE stores SET Reviews = (select COUNT(*) from reviews where storeid = stores.id)
where id = 3

UPDATE stores SET avgreviewscore = (select AVG(score) from reviews where storeid = stores.id)
where id = 3

select * from customers
select * from stores
select * from inventory
select * from reviews
select * from orderhistory