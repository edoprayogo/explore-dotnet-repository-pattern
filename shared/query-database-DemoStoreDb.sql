-- =========================
-- CREATE DATABASE
-- =========================
CREATE DATABASE DemoStoreDb;
GO

USE DemoStoreDb;
GO

-- =========================
-- TABLE: Stores
-- =========================
CREATE TABLE Stores (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
GO

-- =========================
-- TABLE: Categories
-- =========================
CREATE TABLE Categories (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    StoreId UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(100) NOT NULL,

    CONSTRAINT FK_Categories_Stores
        FOREIGN KEY (StoreId) REFERENCES Stores(Id)
        ON DELETE CASCADE
);
GO

-- =========================
-- TABLE: Products
-- =========================
CREATE TABLE Products (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    CategoryId UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(150) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,

    CONSTRAINT FK_Products_Categories
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
        ON DELETE CASCADE
);
GO

-- =========================
-- TABLE: Orders
-- =========================
CREATE TABLE Orders (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    ProductId UNIQUEIDENTIFIER NOT NULL,
    Quantity INT NOT NULL,
    OrderDate DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Orders_Products
        FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO


USE DemoStoreDb;
GO

-- =========================
-- DECLARE IDS
-- =========================
DECLARE @StoreId UNIQUEIDENTIFIER = NEWID();
DECLARE @CategoryFoodId UNIQUEIDENTIFIER = NEWID();
DECLARE @CategoryDrinkId UNIQUEIDENTIFIER = NEWID();
DECLARE @ProductBurgerId UNIQUEIDENTIFIER = NEWID();
DECLARE @ProductCoffeeId UNIQUEIDENTIFIER = NEWID();
DECLARE @Order1Id UNIQUEIDENTIFIER = NEWID();
DECLARE @Order2Id UNIQUEIDENTIFIER = NEWID();

-- =========================
-- INSERT STORE
-- =========================
INSERT INTO Stores (Id, Name)
VALUES (@StoreId, 'Main Store');

-- =========================
-- INSERT CATEGORIES
-- =========================
INSERT INTO Categories (Id, StoreId, Name)
VALUES
(@CategoryFoodId,  @StoreId, 'Food'),
(@CategoryDrinkId, @StoreId, 'Drink');

-- =========================
-- INSERT PRODUCTS
-- =========================
INSERT INTO Products (Id, CategoryId, Name, Price)
VALUES
(@ProductBurgerId, @CategoryFoodId,  'Burger', 25000),
(@ProductCoffeeId, @CategoryDrinkId, 'Coffee', 15000);

-- =========================
-- INSERT ORDERS
-- =========================
INSERT INTO Orders (Id, ProductId, Quantity)
VALUES
(@Order1Id, @ProductBurgerId, 2),
(@Order2Id, @ProductCoffeeId, 1);
