use mvcdb

CREATE TABLE Category (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL
);

CREATE TABLE SubCategory (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Category(Id)
);

CREATE TABLE ProductData (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    Price int NOT NULL,
    SubCategoryId INT FOREIGN KEY REFERENCES SubCategory(Id)
);

INSERT INTO Category (Name) VALUES
('Electronics'),
('Clothing'),
('Home Appliances'),
('Books'),
('Sports');


INSERT INTO SubCategory (Name, CategoryId) VALUES
-- Subcategories for Electronics
('Mobile Phones', 1),
('Laptops', 1),
('Tablets', 1),

-- Subcategories for Clothing
('Men', 2),
('Women', 2),
('Kids', 2),

-- Subcategories for Home Appliances
('Refrigerators', 3),
('Washing Machines', 3),
('Microwaves', 3),

-- Subcategories for Books
('Fiction', 4),
('Non-Fiction', 4),
('Comics', 4),

-- Subcategories for Sports
('Outdoor', 5),
('Indoor', 5),
('Gym Equipment', 5);

INSERT INTO ProductData(Name, Price, SubCategoryId) VALUES
-- Products for Mobile Phones
('iPhone 13', 999, 1),
('Samsung Galaxy S22', 799, 1),
('OnePlus 10', 699, 1),

-- Products for Laptops
('MacBook Air', 1199, 2),
('Dell XPS 13', 1099, 2),
('HP Spectre x360', 1299, 2),

-- Products for Tablets
('iPad Pro', 799, 3),
('Samsung Galaxy Tab', 599, 3),
('Microsoft Surface Go', 399, 3),

-- Products for Men Clothing
('T-Shirt', 19, 4),
('Jeans', 49, 4),
('Jacket', 79, 4),

-- Products for Women Clothing
('Dress', 39, 5),
('Skirt', 29, 5),
('Blouse', 24, 5),

-- Products for Refrigerators
('LG Refrigerator', 899, 7),
('Samsung Refrigerator', 799, 7),
('Whirlpool Refrigerator', 699, 7),

-- Products for Fiction Books
('The Great Gatsby', 14, 10),
('To Kill a Mockingbird', 18, 10),
('1984', 15, 10),

-- Products for Outdoor Sports
('Football', 19, 13),
('Cricket Bat', 49, 13),
('Tennis Racket', 89, 13),

-- Products for Gym Equipment
('Treadmill', 599, 15),
('Dumbbells Set', 149, 15),
('Exercise Bike', 399, 15);
