CREATE TABLE Airplanes (
    AirplaneId INT PRIMARY KEY IDENTITY(1,1),
    Manufacturer NVARCHAR(255) NOT NULL,
    Nickname NVARCHAR(255) NOT NULL,
    YearOfManufacture INT NOT NULL,
    ImageUrl NVARCHAR(255) NOT NULL
);

CREATE TABLE Users (
    UserId INT PRIMARY KEY,
    FullName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role INT NOT NULL,
    CONSTRAINT UQ_UserNamePassword UNIQUE (FullName, Password)
);

CREATE TABLE Flights (
    FlightId INT PRIMARY KEY IDENTITY(1,1),
    AirplaneId INT NOT NULL,
    DepartureLocation NVARCHAR(255) NOT NULL,
    ArrivalLocation NVARCHAR(255) NOT NULL,
    DepartureTime DATETIME NOT NULL,
    ArrivalTime DATETIME NOT NULL,
    FOREIGN KEY (AirplaneId) REFERENCES Airplanes(AirplaneId)
);

CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY(1,1),
    PassengerID INT NOT NULL,
    FlightId INT NOT NULL,
    FOREIGN KEY (PassengerID) REFERENCES Users(UserId), 
    FOREIGN KEY (FlightId) REFERENCES Flights(FlightId)
);



INSERT INTO Airplanes (Manufacturer, Nickname, YearOfManufacture, ImageUrl)
VALUES 
('Boeing', 'Dreamliner', 2018, 'https://example.com/dreamliner.jpg'),
('Airbus', 'A320', 2020, 'https://example.com/a320.jpg'),
('Boeing', '747 Jumbo', 2016, 'https://example.com/jumbo.jpg'),
('Embraer', 'E195', 2019, 'https://example.com/e195.jpg'),
('Cessna', 'Citation', 2017, 'https://example.com/citation.jpg');



INSERT INTO Flights (AirplaneId, DepartureLocation, ArrivalLocation, DepartureTime, ArrivalTime)
VALUES 
(5, 'New York', 'London', '2024-10-01 08:00', '2024-10-01 20:00'),
(3, 'Los Angeles', 'Tokyo', '2024-10-02 10:00', '2024-10-03 12:00'),
(7, 'Paris', 'Berlin', '2024-10-03 09:00', '2024-10-03 11:00'),
(6, 'Sydney', 'Auckland', '2024-10-04 14:00', '2024-10-04 16:00'),
(9, 'Toronto', 'Vancouver', '2024-10-05 13:00', '2024-10-05 15:00');

INSERT INTO Users (FullName, Email, Password, Role)
VALUES 
('John Doe', 'john@example.com', 'password123', 1),  -- 1 for Passenger
('Jane Smith', 'jane@example.com', 'mypassword', 1),  -- 1 for Passenger
('Admin User', 'admin@example.com', 'adminpassword', 2), -- 2 for Admin
('Alice Brown', 'alice@example.com', 'alicepass', 1),  -- 1 for Passenger
('Bob Johnson', 'bob@example.com', 'bobpass', 1);  -- 1 for Passenger

INSERT INTO Bookings (PassengerID, FlightId)
VALUES 
(1, 4),
(2, 4),
(1, 5),
(3, 6),
(2, 7);

SELECT * FROM Bookings;
SELECT * FROM Users;
SELECT * FROM Flights;
SELECT * FROM Airplanes;
