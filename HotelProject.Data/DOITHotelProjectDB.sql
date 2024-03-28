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
	ManagerId INT UNIQUE FOREIGN KEY REFERENCES Managers(Id)
)

INSERT INTO Managers(FirstName,SecondName)
VALUES
(N'Giorgi',N'Gujarelidze'),
(N'Saba',N'Gujarelidze'),
(N'Levani',N'Gujarelidze'),
(N'Nika',N'Gujarelidze')

INSERT INTO Hotels(HotelName,Rating,Country,City,PhysicalAddress,ManagerId)
VALUES
(N'Radisson Blu',N'4.5',N'Georgia',N'Tbilisi',N'Rose_Revolution_Square',N'1'),
(N'The Biltmore',N'4',N'Georgia',N'Tbilisi',N'Shota_Rustaveli_Ave',N'2'),
(N'Rooms Hotel',N'4.3',N'Georgia',N'Tbilisi',N'Merab_Kostava_Street',N'3')

SELECT * FROM Managers

SELECT * FROM Hotels