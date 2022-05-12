use master;
go
drop database if exists TestEBlockbuster;
go
create database TestEBlockbuster;
go
use TestEBlockbuster;
go

create table SecurityLevel (
    SecurityLevelId int primary key identity(1,1),
    [Level] varchar(25) not null
);

create table CreditCard (
    CreditCardId int primary key identity(1,1),
    [Number] varchar(50) not null,
    ExpDate datetime not null,
    SVC varchar(3) not null,
    BillingAddress varchar(125) not null,
    City varchar(50) not null,
    [State] varchar(50) not null,
    Zipcode int not null
);

create table [Login] (
    LoginId  int primary key identity(1,1),
    UserName varchar(50) not null unique,
    [Password] varchar(15) not null,
    SecurityLevelId int not null
    constraint fk_Login_SecurityLevelId
        foreign key (SecurityLevelId)
        references SecurityLevel(SecurityLevelId),
);

create table Customer (
    CustomerId int primary key identity(1,1),
    FirstName varchar(50) not null,
    LastName varchar(50) not null,
    Email varchar(50) not null,
    Phone varchar(50) not null,
    CreditCardId int not null,
    LoginId int not null
    constraint fk_Customer_LoginId
        foreign key (LoginId)
        references [Login](LoginId),
    constraint fk_Customer_CreditCardId
        foreign key (CreditCardId)
        references CreditCard(CreditCardId)
);

create table Administrator(
    AdminId int primary key identity(1,1),
    FirstName varchar(50) not null,
    LastName varchar(50) not null,
    LoginId int not null
    constraint fk_Administrator_LoginId
        foreign key (LoginId)
        references [Login](LoginId),
);

create table Category(
    CategoryId int primary key identity(1,1),
    [Name] varchar(100) not null
);

create table Product(
    ProductId int primary key identity(1,1),
    [Name] varchar(100) not null,
    Price decimal(4,2) not null,
    Photo varchar(125) not null,
    CategoryId int not null,
    constraint fk_Product_CategoryId
        foreign key (CategoryId)
        references Category(CategoryId),
);

create table ProductCustomer(
    ProductId int not null,
    CustomerId int not null,
    constraint fk_ProductCustomer_ProductId
        foreign key (ProductId)
        references Product(ProductId),
    constraint fk_ProductCustomer_CustomerId
        foreign key (CustomerId)
        references Customer(CustomerId),
);