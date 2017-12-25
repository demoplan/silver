create table CustomerM(
ID int identity primary key,
Code varchar(50),
CustName varchar(100),
CustAddress varchar(250),
Phone varchar(20),
Email varchar(100),
PAN varchar(10),
CustType varchar(1)
)

create table ProductM(
ID int identity primary key,
ItemCode varchar(250),
PName varchar(250)
)

create table MetalM(
ID int identity primary key,
MetalDesc varchar(250)
)

--drop table Receipt
create table Receipt(
ID int identity primary key,
VNo int,
VDate datetime,
CustType varchar(1),
LCode varchar(50),
GrossWt dec(16,4),
NetWt dec(16,4),
MakingTotal dec(16,4),
Remarks varchar(max)
)

--drop table InOut
create table InOut(
TID int identity primary key,
SeqNo int not null,
TDate datetime,
PCode varchar(50),
MetalType varchar(250),
TType varchar(3),--IN/OUT
RefVNo int,
JobNo int,
OrderNo int,
Pcs dec(16,4),--Only int then why decimal
GrossWt dec(16,4),
NetWt dec(16,4),
MakingRate dec(16,4),
TotalRate dec(16,4),
SellingRate dec(16,4)
)

--drop table StockInfo
create table StockInfo(
TID int identity primary key,
SeqNo int not null,
TDate datetime,
PCode varchar(50),
BarCode varchar(50),
MetalType varchar(250),
InType varchar(10),--IN/OUT
RefVNo int,
JobNo int,
OrderNo int,
Pcs dec(16,4),
GrossWt dec(16,4),
NetWt dec(16,4),
MakingRate dec(16,4),
TotalRate dec(16,4),
SellingRate dec(16,4),
Photo varchar(200),
OutDate datetime,
OutBillNo int,
OutType varchar(10)
)

-- drop table OrderDetail
create table OrderDetail(
TID int identity primary key,
orderNo int not null,
orderDate datetime,
LCode varchar(50),
PCode varchar(50),
qty int,
weight dec(16,3),
KID varchar(10),
artisanReqDate datetime,
orderPlacedDate datetime,
orderRecdDate datetime,
jobNo int,
orderType varChar(1),
totalweight dec(16,3)
)

--drop table CustomerOrderInfo
create table CustomerOrderInfo(	
TID int identity primary key,
orderNo	int,
orderDate Date,
orderDeliveryDate Date,
lcode	varChar(10),
customerNotifiedByMsg	Date,
customerNotifiedByEmail	Date,
orderTotalQty	int,
orderRecdTotalQty	int,
metalType	varChar(20),
metalRate	dec(16,3),
remark	varChar(250)
)


--drop table Issue
create table Issue(
ID int identity primary key,
VNo int,
VDate datetime,
CustType varchar(1),
LCode varchar(50),
GrossWt dec(16,3),
NetWt dec(16,3),
IssueTotal dec(16,2),
SGST dec(16,2),
CGST dec(16,2),
NetTotal dec(16,2),
Remarks varchar(max)
)

--drop table ExtraSettings
create table ExtraSettings(
ID int identity primary key,
Settingkey varchar(20) not null,
SettingValue varchar(20), 
Remarks varchar(max)
)














