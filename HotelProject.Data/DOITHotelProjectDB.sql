USE DOITHotel_BCTFO

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	HotelName NVARCHAR(50) NOT NULL,
	Rating FLOAT NOT NULL,
	Country NVARCHAR(50) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	PhysicalAddress NVARCHAR(50) NOT NULL,
)

CREATE TABLE Managers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	SecondName NVARCHAR(50) NOT NULL,
	HotelId INT UNIQUE FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE UNIQUE NONCLUSTERED INDEX UniqueHotelID
ON DOITHotel_BCTFO.dbo.Managers (HotelId)
WHERE HotelId IS NOT NULL;

INSERT INTO Hotels(HotelName,Rating,Country,City,PhysicalAddress)
VALUES
(N'Radisson Blu',N'4.5',N'Georgia',N'Tbilisi',N'Rose Revolution Square'),
(N'The Biltmore',N'4',N'Georgia',N'Tbilisi',N'Shota Rustaveli Ave'),
(N'Rooms Hotel',N'4.3',N'Georgia',N'Tbilisi',N'Merab Kostava Street')

INSERT INTO Managers(FirstName,SecondName,HotelId)
VALUES
(N'Giorgi',N'Gujarelidze',N'1'),
(N'Saba',N'Gujarelidze',N'2'),
(N'Levani',N'Gujarelidze',N'3'),
(N'Nika',N'Gujarelidze',null)

CREATE PROCEDURE GetAllManagers
AS
BEGIN
	SELECT [Id]
      ,[FirstName]
      ,[SecondName]
	  ,[HotelId]
  FROM [DOITHotel_BCTFO].[dbo].[Managers]
END

CREATE PROCEDURE GetAllHotels
AS
BEGIN
	SELECT [Id]
      ,[HotelName]
      ,[Rating]
      ,[Country]
      ,[City]
      ,[PhysicalAddress]      
  FROM [DOITHotel_BCTFO].[dbo].[Hotels]
END

CREATE PROCEDURE AddManager
	@firstName NVARCHAR(50),
	@secondName NVARCHAR(50),
	@hotelID INT
AS
BEGIN
	INSERT INTO Managers(FirstName,SecondName,HotelID)
	VALUES(@firstName,@secondName,@HotelID)
END

CREATE PROCEDURE AddHotel
	@HotelName NVARCHAR(50),
	@Rating FLOAT,
	@Country NVARCHAR(50),
	@City NVARCHAR(50),
	@PhysicalAddress NVARCHAR(50)
AS
BEGIN
	INSERT INTO Hotels(HotelName,Rating,Country,City,PhysicalAddress)
	VALUES(@HotelName,@Rating,@Country,@City,@PhysicalAddress)
END

CREATE PROCEDURE UpdateManager
	@firstName NVARCHAR(50),
	@secondName NVARCHAR(50),
	@hotelID INT,
	@id INT
AS
BEGIN
UPDATE Managers
	SET FirstName = @firstName,
		SecondName = @secondName,
		HotelId = @hotelID
	WHERE Id = @id
END

CREATE PROCEDURE UpdateHotel
	@HotelName NVARCHAR(50),
	@Rating FLOAT,
	@Country NVARCHAR(50),
	@City NVARCHAR(50),
	@PhysicalAddress NVARCHAR(50),
	@id INT
AS
BEGIN
UPDATE Hotels
	SET HotelName = @HotelName,
		Rating = @Rating,
		Country = @Country,
		City = @City,
		PhysicalAddress = @PhysicalAddress
	WHERE Id = @id
END

CREATE PROCEDURE DeleteManager
@id INT
AS
BEGIN
	DELETE Managers
	WHERE Id = @id
END

CREATE PROCEDURE DeleteHotel
@id INT
AS
BEGIN
	DELETE Hotels
	WHERE Id = @id
END

