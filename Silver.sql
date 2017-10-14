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

create table Receipt(
ID int identity primary key,
VNo int,
VDate datetime,
LCode varchar(50),
GrossWt dec(16,4),
NetWt dec(16,4),
MakingRate dec(16,4),
MakingCharge dec(16,4),
RoundOff int,
TotalAmt dec(16,4)
)

--drop table InOut
create table InOut(
TID int identity primary key,
SeqNo int not null,
TDate datetime,
LCode varchar(50),
PCode varchar(50),
MetalType varchar(250),
TType varchar(3),--IN/OUT
RefVNo int,
Pcs dec(16,4),--Only int then why decimal
GrossWt dec(16,4),
NetWt dec(16,4),
Rate dec(16,4)
)

--drop table StockInfo
create table StockInfo(
TID int identity primary key,
SeqNo int not null,
TDate datetime,
LCode varchar(50),
PCode varchar(50),
TagNo varchar(50),
MetalType varchar(250),
InType varchar(10),--IN/OUT
RefVNo int,
Pcs dec(16,4),
GrossWt dec(16,4),
NetWt dec(16,4),
Rate dec(16,4),
Photo varchar(200),
OutDate datetime,
OutBillNo int,
OutType varchar(10),
Remarks varchar(250)
)



















