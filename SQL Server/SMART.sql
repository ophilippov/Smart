USE Smart
GO
create table Discounts(
DiscountID int identity(1,1),
constraint pk_discounts_discountID primary key clustered(DiscountID),
[Name] nvarchar(30) not null,
StartDate datetime not null,
EndDate datetime not null,
ProductCount int not null,
DiscountRate float not null
)
GO

GO 
alter table Discounts
add constraint df_discounts_startDate default (getdate()) for [StartDate]
GO

GO
alter table Discounts
add constraint df_discounts_endDate default (getdate()) for [EndDate]
GO

GO
create table Access(
AccessID int identity(1,1),
constraint pk_access_accessID primary key clustered (AccessID),
AccessName varchar(20) not null
)
GO

GO
create table Users(
UserID int identity(1,1),
constraint pk_users_userID primary key clustered(UserId),
UserLogin varchar(15) not null,
constraint un_users_userLogin unique (UserLogin),
UserPassword varchar(20) not null,
UserPost nvarchar(20) not null,
UserFIO nvarchar(50) not null
)
GO

GO
create table Customers(
CustomerID int identity(1,1),
constraint pk_customers_customerID primary key clustered(CustomerID),
ContactFIO nvarchar(50) not null,
Name nvarchar(50) not null,
LegalAddress nvarchar(100) not null,
NCertificate varchar(10) not null,
ITN varchar(12) not null,
EDRPOU varchar(8) not null,
BankAccount varchar(20) not null,
BankMFO varchar(6) not null,
BankName nvarchar(50) not null,
[E-mail] varchar(50) not null,
Website varchar(20),
DirectorFIO nvarchar(50) not null,
PayDelay int not null,
Fine float not null
)
GO

GO
create table Suppliers(
SupplierID int identity(1,1),
constraint pk_suppliers_supplierID primary key clustered(SupplierID),
ContactFIO nvarchar(50) not null,
Name nvarchar(50) not null,
LegalAddress nvarchar(100) not null,
NCertificate varchar(10) not null,
ITN varchar(12) not null,
EDRPOU varchar(8) not null,
BankAccount varchar(20) not null,
BankMFO varchar(6) not null,
BankName nvarchar(50) not null,
[E-mail] varchar(50) not null,
Website varchar(20),
DirectorFIO nvarchar(50) not null
)
GO

GO
create table Products(
ProductID int identity(1,1),
constraint pk_products_productsID primary key clustered(ProductID),
Name nvarchar(30) not null,
CountPacking int not null,
RetailCostUAH float not null,
RetailCostUSD float not null,
WholesaleCostUAH float not null,
WholesaleCostUSD float not null,
Vendor bigint not null,
UKTZED varchar(10) not null,
Barcode varchar(30) not null,
PackingWeight float not null,
PackingLength float not null,
PackingWidth float not null,
PackingHeight float not null,
ProductWeight float not null,
ProductLength float not null,
ProductWidth float not null,
ProductHeight float not null,
Volume float not null
)
GO

GO
create table SC(
SC_ID int identity(1,1),
constraint pk_sc_scID primary key clustered (SC_ID),
Name nvarchar(50) not null
)
GO



GO
create table SC_Cities(
SC_CityID int identity(1,1),
constraint pk_scCities_scCityID primary key clustered (SC_CityID),
Country nvarchar(20) not null,
Region nvarchar(30) not null,
District nvarchar(30) not null,
City nvarchar(30) not null,
ZIP varchar(10) not null,
SC_ID int not null,
constraint fk_scCities_scID foreign key (SC_ID) references SC(SC_ID) on update cascade on delete cascade
)
GO

GO
create table SC_Offices(
SC_OfficeID int identity(1,1),
constraint pk_scOffices_scOfficeID primary key clustered (SC_OfficeID),
Number varchar(5) not null,
Street nvarchar(30) not null,
House varchar(5) not null,
SC_ID int not null,
constraint fk_scOffices_scID foreign key (SC_ID) references SC(SC_ID) on update no action on delete no action,
SC_CityID int not null,
constraint fk_scOffices_scCityID foreign key (SC_CityID) references SC_Cities(SC_CityID) on update cascade on delete cascade
)
GO

GO
create table SA(
SA_ID int identity(1,1),
constraint pk_sa_saID primary key clustered (SA_ID),
Country nvarchar(20) not null,
Region nvarchar(30) not null,
District nvarchar(30) not null,
City nvarchar(30) not null,
Street nvarchar(30) not null,
House varchar(5) not null,
Apartment varchar(5) not null,
ZIP varchar(10) not null,
CustomerID int not null,
constraint fk_sa_customerID foreign key (CustomerID) references Customers(CustomerID) on update cascade on delete cascade
)
GO

GO
create table Suppliers_Phones(
Supplier_PhoneID int identity(1,1),
constraint pk_suppliersPhones_supplierPhoneID primary key clustered (Supplier_PhoneID),
Name nvarchar(20) not null,
Number varchar(13) not null,
SupplierID int not null,
constraint fk_suppliersPhones_supplierID foreign key (SupplierID) references Suppliers(SupplierID) on update cascade on delete cascade
)
GO


GO
create table Customers_Phones(
Customer_PhoneID int identity(1,1),
constraint pk_customersPhones_customerPhoneID primary key clustered (Customer_PhoneID),
Name nvarchar(20) not null,
Number varchar(13) not null,
CustomerID int not null,
constraint fk_customersPhones_customerID foreign key (CustomerID) references Customers(CustomerID) on update cascade on delete cascade
)
GO


GO
create table Users_Access(
User_AccessID int identity(1,1),
constraint pk_usersAccess_userAccessID primary key clustered(User_AccessID),
UserID int not null,
constraint fk_usersAccess_userID foreign key (UserID) references Users(UserID) on update cascade on delete cascade,
AccessID int not null,
constraint fk_usersAccess_accessID foreign key (AccessID) references Access(AccessID) on update cascade on delete cascade
)
GO

GO
create table Discounts_Products(
Discount_ProductID int identity(1,1),
constraint pk_discountsProducts_discountProductID primary key clustered (Discount_ProductID),
DiscountID int not null,
constraint fk_discountsProducts_discountID foreign key (DiscountID) references Discounts(DiscountID) on update cascade on delete cascade,
ProductID int not null,
constraint fk_discountsProducts_productID foreign key (ProductID) references Products(ProductID) on update cascade on delete cascade
)
GO

GO
create table Discounts_Customers(
Discount_CustomerID int identity(1,1),
constraint pk_discountsCustomers_discountCustomerID primary key clustered (Discount_CustomerID),
DiscountID int not null,
constraint fk_discountsCustomers_discountID foreign key (DiscountID) references Discounts(DiscountID) on update cascade on delete cascade,
CustomerID int not null,
constraint fk_discountsCustomers_customerID foreign key (CustomerID) references Customers(CustomerID) on update cascade on delete cascade
)
GO

GO
create table Incomes(
IncomeID int identity(1,1),
constraint pk_incomes_incomeID primary key clustered (IncomeID),
SupplierID int null,
constraint fk_incomes_supplierID foreign key (SupplierID) references Suppliers(SupplierID) on update cascade on delete set null,
IncomeDate datetime not null,
InvoiceNumber varchar(20) not null
)
GO

GO
alter table Incomes
add constraint df_incomes_incomeDate default (getdate()) for IncomeDate
GO

GO
create table Incomes_Products(
Income_ProductsID int identity(1,1),
constraint pk_incomesProducts_incomeProductID primary key clustered (Income_ProductsID),
IncomeID int not null,
constraint fk_incomesProducts_incomeID foreign key (IncomeID) references Incomes(IncomeID) on update cascade on delete cascade,
ProductID int null,
constraint fk_incomesProducts_productID foreign key (ProductID) references Products(ProductID) on update cascade on delete set null,
[Count] int not null,
Cost float not null,
Vendor bigint not null
)
GO

GO 
create table Outcomes(
OutcomeID int identity(1,1),
constraint pk_outcomes_outcomeID primary key clustered (OutcomeID),
UserID int null,
constraint fk_outcomes_userID foreign key (UserID) references Users(UserID) on update cascade on delete set null,
OutcomeDate datetime not null,
InvoiceNumber varchar(20) not null
)
GO

GO 
alter table Outcomes
add constraint df_outcomes_outcomeDate default (getdate()) for OutcomeDate
GO

GO
create table Outcomes_Products(
Outcomes_ProductID int identity(1,1),
constraint pk_outcomesProducts_outcomesProductID primary key clustered (Outcomes_ProductID),
OutcomeID int not null,
constraint fk_outcomesProducts_outcomeID foreign key (OutcomeID) references Outcomes(OutcomeID) on update cascade on delete cascade,
Name nvarchar(30) not null,
Vendor bigint not null,
[Count] int not null,
Cost float not null
)
GO


GO
create table Stock(
StockID int identity(1,1),
constraint pk_stock_stockID primary key clustered (StockID),
ProductID int not null,
constraint fk_stock_productID foreign key (ProductID) references Products(ProductID) on update cascade on delete cascade,
[Count] int not null
)
GO


GO
create table Payments(
PaymentID int identity(1,1),
constraint pk_payments_paymentID primary key clustered (PaymentID),
[Date] datetime not null,
Summ float not null
)
GO

GO
alter table Payments
add constraint df_payments_date default (getdate()) for [Date]
GO

GO
create table Shipping_Types(
Shipping_TypeID int identity(1,1),
constraint pk_shippingTypes_shippingTypeID primary key clustered (Shipping_TypeID),
Name varchar(20) not null
)
GO

GO
create table StatusO(
StatusOID int identity(1,1),
constraint pk_statusO_statusOID primary key clustered (StatusOID),
Name varchar(20) not null
)
GO

GO
create table StatusP(
StatusPID int identity(1,1),
constraint pk_statusP_statusPID primary key clustered (StatusPID),
Name varchar(20) not null
)
GO

GO
create table Orders(
OrderID int identity(1,1),
constraint pk_orders_orderID primary key clustered (OrderID),
CreateDate datetime not null,
InvoiceNumber varchar(20) not null,
CustomerID int null,
constraint fk_orders_customerID foreign key (CustomerID) references Customers(CustomerID) on update cascade on delete set null,
StatusPID int not null,
constraint fk_orders_statusPID foreign key (StatusPID) references StatusP(StatusPID) on update cascade on delete cascade,
Shipping_TypeID int not null,
constraint fk_orders_shippingTypeID foreign key (Shipping_TypeID) references Shipping_Types(Shipping_TypeID) on update cascade on delete cascade,
SC_OfficeID int null,
constraint fk_orders_scOfficeID foreign key (SC_OfficeID) references SC_Offices(SC_OfficeID) on update cascade on delete set null,
SA_ID int null,
constraint fk_orders_saID foreign key (SA_ID) references SA(SA_ID) on update no action on delete no action,
OrderDiscountID int null,
constraint fk_orders_orderDiscountID foreign key (OrderDiscountID) references Discounts(DiscountID) on update cascade on delete set null

)
GO

GO
alter table Orders
add constraint df_orders_createDate default (getdate()) for CreateDate
GO

GO
create table Orders_Products(
OrderProductID int identity(1,1),
constraint pk_ordersProducts_orderProductID primary key clustered (OrderProductID),
CountRequest int not null,
[Count] int not null,
OrderID int not null,
Cost float not null,
Vendor bigint not null,
constraint fk_ordersProducts_orderID foreign key (OrderID) references Orders(OrderID) on update cascade on delete cascade,
ProductID int null,
constraint fk_ordersProducts_productID foreign key (ProductID) references Products(ProductID) on update cascade on delete set null,
DiscountID int null,
constraint fk_ordersProducts_discountID foreign key (DiscountID) references Discounts(DiscountID) on update no action on delete no action
)
GO

GO
create table Orders_Payments(
Order_PaymentID int identity(1,1),
constraint pk_ordersPayments_orderPaymentID primary key clustered (Order_PaymentID),
OrderID int not null,
constraint fk_ordersPayments_orderID foreign key (OrderID) references Orders(OrderID) on update cascade on delete cascade,
PaymentID int not null,
constraint fk_ordersPayments_paymentID foreign key (PaymentID) references Payments(PaymentID) on update cascade on delete cascade
)
GO

GO
create table Orders_Status(
Order_StatusID int identity (1,1),
constraint pk_ordersStatus_orderStatusID primary key clustered (Order_StatusID),
OrderID int not null,
constraint fk_ordersStatus_orderID foreign key (OrderID) references Orders(OrderID) on update cascade on delete cascade,
StatusOID int not null,
constraint fk_ordersStatus_statusOID foreign key (StatusOID) references StatusO(StatusOID) on update cascade on delete cascade,
[Date] datetime not null,
Comment nvarchar(30) null
)
GO

GO
alter table Orders_Status
add constraint df_orderStatus_date default (getdate()) for [Date]
GO

GO
create table Users_Orders(
User_OrderID int identity(1,1),
constraint pk_usersOrders_userOrderID primary key clustered (User_OrderID),
UserID int not null,
constraint fk_usersOrders_userID foreign key (UserID) references Users(UserID) on update cascade on delete cascade,
OrderID int not null,
constraint fk_usersOrders_orderID foreign key (OrderID) references Orders(OrderID) on update cascade on delete cascade,
Modification nvarchar(100) not null,
[Date] datetime not null
)
GO

GO
alter table Users_Orders
add constraint df_usersOrders_date default (getdate()) for [Date]
GO


