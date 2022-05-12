use TestEBlockbuster;

  DELETE FROM ProductCustomer

  DELETE FROM Customer
  DBCC CHECKIDENT ('TestEBlockbuster.dbo.Customer', RESEED, 0)

  DELETE FROM Product
  DBCC CHECKIDENT ('TestEBlockbuster.dbo.Product', RESEED, 0)

  DELETE FROM Administrator
  DBCC CHECKIDENT ('TestEBlockbuster.dbo.Administrator', RESEED, 0)

  DELETE FROM Category
  DBCC CHECKIDENT ('TestEBlockbuster.dbo.Category', RESEED, 0)

  DELETE FROM [Login]
  DBCC CHECKIDENT ('TestEBlockbuster.dbo.Login', RESEED, 0)

  DELETE FROM CreditCard
  DBCC CHECKIDENT ('TestEBlockbuster.dbo.CreditCard', RESEED, 0)

  DELETE FROM SecurityLevel
  DBCC CHECKIDENT ('TestEBlockbuster.dbo.SecurityLevel', RESEED, 0)

-- SecurityLevel

insert into SecurityLevel ([Level]) values ('Administrator');
insert into SecurityLevel ([Level]) values ('Customer');

-- Login
-- Admins
insert into Login (Username, [Password], SecurityLevelId) values ('martheletson', 'grUrWj4', 1);
insert into Login (Username, [Password], SecurityLevelId) values ('sheelahantonat', 'zvGtMfOdub8', 1);
insert into Login (Username, [Password], SecurityLevelId) values ('austinarogerot', 'VBzr8jIu7u', 1);
insert into Login (Username, [Password], SecurityLevelId) values ('ivorygregoletti', 'L5CPdwhm17y4', 1);
insert into Login (Username, [Password], SecurityLevelId) values ('jarradivanishev', 'oEYL4TlLyag', 1);

-- Customers

insert into Login (Username, [Password], SecurityLevelId) values ('sapphirelivock', 'qvy5aI', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('jenolaity', 't2gape6K', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('franceneharburtson', 'TxNVh6', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('maximilianusbullers', 'JfkfhPmrt', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('ramseyrickell', 'ZEHeQx', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('margretspileman', 'WGOSAvElu', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('merraleebeckers', 'bq5boLT', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('danitafarbrace', 'lclZneHK3', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('artusstclair', '9toaVEU', 2);
insert into Login (Username, [Password], SecurityLevelId) values ('laurentkarim', 'AJ7nvOteA', 2);

-- Administrator

insert into Administrator (FirstName, LastName, LoginId) values ('Marthe', 'Letson', 1);
insert into Administrator (FirstName, LastName, LoginId) values ('Sheelah', 'Antonat', 2);
insert into Administrator (FirstName, LastName, LoginId) values ('Austina', 'Rogerot', 3);
insert into Administrator (FirstName, LastName, LoginId) values ('Ivory', 'Gregoletti', 4);
insert into Administrator (FirstName, LastName, LoginId) values ('Jarrad', 'Ivanishev', 5);

-- Category

insert into Category ([Name]) values ('Action');
insert into Category ([Name]) values ('Drama');
insert into Category ([Name]) values ('Horror');
insert into Category ([Name]) values ('Comedy');
insert into Category ([Name]) values ('Romance');
insert into Category ([Name]) values ('Sci-Fi');
insert into Category ([Name]) values ('Animation');
insert into Category ([Name]) values ('Thriller');
insert into Category ([Name]) values ('Documentary');
insert into Category ([Name]) values ('Adventure');

-- Credit Card

insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5048375119895091', 2023-11, 637, '286 Mcbride Alley', 'Van Nuys', 'CA', '91406');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5108755338703795', 2025-07, 691, '25 Carey Trail', 'Springfield', 'MA', '01152');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5108756093665799', 2024-09, 288, '287 Meadow Valley Park', 'Atlanta', 'GA', '31196');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5048374496505167', 2025-10, 581, '4677 East Trail', 'Tulsa', 'OK', '74170');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5048375156323528', 2025-09, 771, '5 Ludington Road', 'Phoenix', 'AZ', '85015');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5108755956985724', 2024-08, 343, '52 Vermont Street', 'Tallahassee', 'FL', '32309');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5048371570020667', 2025-03, 841, '91 Crescent Oaks Crossing', 'Lincoln', 'NE', '68531');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5048371476387236', 2025-12, 243, '1189 Randy Drive', 'Largo', 'FL', '33777');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5048374587367097', 2024-12, 750, '6407 Sycamore Lane', 'Charleston', 'SC', '29424');
insert into CreditCard ([Number], ExpDate, SVC, BillingAddress, City, [State], Zipcode) values ('5108752764740979', 2024-03, 519, '59475 Maple Park', 'Boynton Beach', 'FL', '33436');

-- Customer

insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Sapphire', 'Livock', 'slivock0@4shared.com', '805-788-2597', 1, 6);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Jeno', 'Laity', 'jlaity1@i2i.jp', '413-373-8519', 2, 7);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Francene', 'Harburtson', 'fharburtson2@salon.com', '404-482-8248', 3, 8);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Maximilianus', 'Bullers', 'mbullers3@slideshare.net', '918-199-1243', 4, 9);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Ramsey', 'Rickell', 'rrickell4@symantec.com', '602-316-5578', 5, 10);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Margret', 'Spileman', 'mspileman5@sitemeter.com', '850-793-3381', 6, 11);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Merralee', 'Beckers', 'mbeckers6@domainmarket.com', '402-515-0588', 7, 12);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Danita', 'Farbrace', 'dfarbrace7@intel.com', '727-292-9074', 8, 13);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Artus', 'St Clair', 'astclair8@alibaba.com', '843-157-3529', 9, 14);
insert into Customer (FirstName, LastName, Email, Phone, CreditCardId, LoginId) values ('Laurent', 'Karim', 'lkarim9@photobucket.com', '561-989-5389', 10, 15);

-- Product

insert into Product ([Name], Price, Photo, CategoryId) values ('Tron', 5.91, 'URL Goes Here', 1);
insert into Product ([Name], Price, Photo, CategoryId) values ('Sel8nne', 7.09, 'Seal, common', 4);
insert into Product ([Name], Price, Photo, CategoryId) values ('+1', 9.05, 'Brocket, red', 5);
insert into Product ([Name], Price, Photo, CategoryId) values ('Deadly Mantis, The', 6.73, 'Ornate rock dragon', 4);
insert into Product ([Name], Price, Photo, CategoryId) values ('Monty Python''s Life of Brian', 10.53, 'Javanese cormorant', 4);
insert into Product ([Name], Price, Photo, CategoryId) values ('Riding the Bullet', 5.21, 'Boa, emerald green tree', 7);
insert into Product ([Name], Price, Photo, CategoryId) values ('Something the Lord Made', 5.51, 'Vulture, oriental white-backed', 2);
insert into Product ([Name], Price, Photo, CategoryId) values ('Felon', 5.51, 'Cockatoo, red-tailed', 6);
insert into Product ([Name], Price, Photo, CategoryId) values ('Walk on the Moon, A', 10.12, 'Chuckwalla', 6);
insert into Product ([Name], Price, Photo, CategoryId) values ('Garden Party', 14.19, 'Snake, buttermilk', 7);

-- ProductCustomer

insert into ProductCustomer (ProductId, CustomerId) values (10,1);
insert into ProductCustomer (ProductId, CustomerId) values (9,2);
insert into ProductCustomer (ProductId, CustomerId) values (8,3);
insert into ProductCustomer (ProductId, CustomerId) values (7,4);
insert into ProductCustomer (ProductId, CustomerId) values (6,5);
insert into ProductCustomer (ProductId, CustomerId) values (5,6);
insert into ProductCustomer (ProductId, CustomerId) values (4,7);
insert into ProductCustomer (ProductId, CustomerId) values (3,8);
insert into ProductCustomer (ProductId, CustomerId) values (2,9);
insert into ProductCustomer (ProductId, CustomerId) values (1,10);