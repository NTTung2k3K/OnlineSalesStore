create database ShopSales
go
create table tb_Category(
	CategoryId int identity(1,1) primary key,
	Title nvarchar(50),
	[Description] nvarchar(500),
	Position int,
	SeoTitle nvarchar(50),
	SeoDescription nvarchar(500),
	SeoKeyword nvarchar(255),
	CreateDate datetime,
	CreateBy nvarchar(255),
	ModifiedDate datetime,
	ModifierBy nvarchar(255),
)
create table tb_ProductCategory(
	ProductCategoryId int identity(1,1) primary key,
	Title nvarchar(50),
	[Description] nvarchar(500),
	Icon varchar(500),
	SeoTitle nvarchar(50),
	SeoDescription nvarchar(500),
	SeoKeyword nvarchar(255),
	CreateDate datetime,
	CreateBy nvarchar(255),
	ModifiedDate datetime,
	ModifierBy nvarchar(255),
)
create table tb_Product(
	ProductId int identity(1,1) primary key,
	Title nvarchar(50),
	[Description] nvarchar(500),
	Detail nvarchar(500),
	Price decimal(18,2),
	PriceSale decimal(18,2),
	Quantity int,
	[Image] varchar(500),
	ProductCategoryId int,
	foreign key (ProductCategoryId) references ProductCategory(ProductCategoryId),
	CreateDate datetime,
	CreateBy nvarchar(255),
	ModifiedDate datetime,
	ModifierBy nvarchar(255),
)
create table [tb_Order](
	OrderId int identity(1,1) primary key,
	Code nvarchar(50),
	CustomerName nvarchar(255),
	Phone varchar(50),
	Quantity int,
	[Address] nvarchar(500),
	TotalAmount decimal(18,2),
	CreateDate datetime,
	CreateBy nvarchar(255),
	ModifiedDate datetime,
	ModifierBy nvarchar(255),
)
create table tb_OrderDetail(
	OrderDetailId int identity(1,1) primary key,
	Quantity int,
	Price decimal(18,2),
	OrderId int,
	ProductId int,
	foreign key (OrderId) references [Order](OrderId),
	foreign key (ProductId) references Product(ProductId),
	Note nvarchar(500)
)

create table tb_Advertisement(
	AdvertisementId int identity (1,1) primary key,
	Title nvarchar(50),
	[Description] nvarchar(500),
	[Type] nvarchar(50),
	Link nvarchar(500),
	Imange nvarchar(500),
	CreateDate datetime,
	CreateBy nvarchar(255),
	ModifiedDate datetime,
	ModifierBy nvarchar(255)
)

create table tb_Contact(
	ContactId int identity(1,1) primary key,
	[Name] nvarchar(255),
	Email varchar(255),
	[Message] nvarchar(500),
	Website nvarchar(500),
	IsRead bit,
	CreateDate datetime,
	CreateBy nvarchar(255),
	ModifiedDate datetime,
	ModifierBy nvarchar(255),
)
create table tb_Subcribe(
	SubcribeId int identity(1,1) primary key,
	Email varchar(500),
	CreateDate datetime
)
create table tb_Setting(
	SettingKey nvarchar(50) primary key,
	SettingValue nvarchar(500),
	SettingDescription nvarchar(500)
)
create table tb_Post(
	PostId int identity(1,1) primary key,
	Title nvarchar(50),
	[Description] nvarchar(500),
	Detail nvarchar(500),
	[Image] varchar(500),
	SeoTitle nvarchar(50),
	SeoDescription nvarchar(500),
	SeoKeyword nvarchar(255),
	CreateDate datetime,
	CreateBy nvarchar(255),
	ModifiedDate datetime,
	ModifierBy nvarchar(255),
	CategoryId int,
	foreign key (CategoryId) references Category(CategoryId)
)
create table tb_News(
	[NewId] int identity(1,1) primary key,
	Title nvarchar(50),
	[Description] nvarchar(500),
	Detail nvarchar(500),
	[Image] varchar(500),
	SeoTitle nvarchar(50),
	SeoDescription nvarchar(500),
	SeoKeyword nvarchar(255),
	CreateDate datetime,
	CreateBy nvarchar(255),
	ModifiedDate datetime,
	ModifierBy nvarchar(255)
)
go