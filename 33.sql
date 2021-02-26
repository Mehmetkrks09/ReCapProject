CREATE TABLE Colors(

Id int PRIMARY KEY IDENTITY(1,1),

ColorName nvarchar(50),
)

CREATE TABLE Brands(

Id int PRIMARY KEY IDENTITY(1,1),

BrandName nvarchar(50),
)

CREATE TABLE Cars(

Id int PRIMARY KEY IDENTITY(1,1),

BrandId int,

ColorId int,

ModelYear nvarchar(25),

DailyPrice decimal,

Descriptions nvarchar(200),

FOREIGN KEY (ColorId) REFERENCES Colors(Id),

FOREIGN KEY (BrandId) REFERENCES Brands(Id)
)