USE DOITHotel_BCTFO


CREATE TABLE Managers
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	SecondName NVARCHAR(50) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	HotelName NVARCHAR(50) NOT NULL,
	Rating FLOAT NOT NULL,
	Country NVARCHAR(50) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	PhysicalAddress NVARCHAR(50) NOT NULL,
	ManagerId INT FOREIGN KEY REFERENCES Managers(Id)
)

CREATE UNIQUE NONCLUSTERED INDEX UniqueManagerID
ON DOITHotel_BCTFO.dbo.Hotels (ManagerId)
WHERE ManagerId IS NOT NULL;


INSERT INTO Managers(FirstName,SecondName)
VALUES
(N'Giorgi',N'Gujarelidze'),
(N'Saba',N'Gujarelidze'),
(N'Levani',N'Gujarelidze'),
(N'Nika',N'Gujarelidze')

INSERT INTO Hotels(HotelName,Rating,Country,City,PhysicalAddress,ManagerId)
VALUES
(N'Radisson Blu',N'4.5',N'Georgia',N'Tbilisi',N'Rose Revolution Square',N'1'),
(N'The Biltmore',N'4',N'Georgia',N'Tbilisi',N'Shota Rustaveli Ave',N'2'),
(N'Rooms Hotel',N'4.3',N'Georgia',N'Tbilisi',N'Merab Kostava Street',N'3')


CREATE PROCEDURE GetAllManagers
AS
BEGIN
	SELECT [Id]
      ,[FirstName]
      ,[SecondName]
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
      ,[ManagerId]
  FROM [DOITHotel_BCTFO].[dbo].[Hotels]
END

CREATE PROCEDURE AddManager
	@firstName NVARCHAR(50),
	@secondName NVARCHAR(50)
AS
BEGIN
	INSERT INTO Managers(FirstName,SecondName)
	VALUES(@firstName,@secondName)
END

CREATE PROCEDURE AddHotel
	@HotelName NVARCHAR(50),
	@Rating FLOAT,
	@Country NVARCHAR(50),
	@City NVARCHAR(50),
	@PhysicalAddress NVARCHAR(50),
	@ManagerId INT
AS
BEGIN
	INSERT INTO Hotels(HotelName,Rating,Country,City,PhysicalAddress,ManagerId)
	VALUES(@HotelName,@Rating,@Country,@City,@PhysicalAddress,@ManagerId)
END

CREATE PROCEDURE UpdateManager
	@firstName NVARCHAR(50),
	@secondName NVARCHAR(50),
	@id int
AS
BEGIN
UPDATE Managers
	SET FirstName = @firstName,
		SecondName = @secondName
	WHERE Id = @id
END

CREATE PROCEDURE UpdateHotel
	@HotelName NVARCHAR(50),
	@Rating FLOAT,
	@Country NVARCHAR(50),
	@City NVARCHAR(50),
	@PhysicalAddress NVARCHAR(50),
	@ManagerId INT,
	@id INT
AS
BEGIN
UPDATE Hotels
	SET HotelName = @HotelName,
		Rating = @Rating,
		Country = @Country,
		City = @City,
		PhysicalAddress = @PhysicalAddress,
		ManagerId = @ManagerId
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

