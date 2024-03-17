DROP DATABASE IF EXISTS ticketmodel;
CREATE DATABASE  IF NOT EXISTS ticketmodel;

/* Switch to the ticketmodel database */
USE ticketmodel;

-- Create the Person table
CREATE TABLE Person (
    CustomerID INT PRIMARY KEY,
    Fname VARCHAR(255),
    Sname VARCHAR(255),
    Address VARCHAR(255),
    DateOfBirth DATE
);

-- Create the PaymentDetails table with a unique index
CREATE TABLE PaymentDetails (
    CardType VARCHAR(255),
    CardNumber VARCHAR(20),
    SecurityCode VARCHAR(4),
    ExpiryDate DATE,
    CustomerID INT,
    PRIMARY KEY (CardType, CardNumber, SecurityCode),
    FOREIGN KEY (CustomerID) REFERENCES Person(CustomerID)
);

-- Create the Event table
CREATE TABLE Event (
    EventID INT PRIMARY KEY,
    EventName VARCHAR(255),
    Date DATE,
    StartTime TIME,
    EndTime TIME,
    VenueName VARCHAR(255),
    Postcode VARCHAR(10),
    Address VARCHAR(255),
    City VARCHAR(255),
    VenueCapacity INT,
    Details VARCHAR(255)
);

-- Create the DiscountCodes table
CREATE TABLE DiscountCodes (
    Code VARCHAR(10) PRIMARY KEY,
    DiscountAmount DECIMAL(10, 2),
    ExpirationDate DATE,
    EventID INT,
    FOREIGN KEY (EventID) REFERENCES Event(EventID)
);

-- Create the TicketType table
CREATE TABLE TicketType (
    TicketTypeID INT PRIMARY KEY,
    Price DECIMAL(10, 2),
    TicketType VARCHAR(255),
    MaxAmount INT,
    EventID INT,
    FOREIGN KEY (EventID) REFERENCES Event(EventID)
);

-- Create the Booking table
CREATE TABLE Booking (
    BookingRef INT AUTO_INCREMENT PRIMARY KEY,
    TotalCost DECIMAL(10, 2),
    BookingDate DATE,
    BookingTime TIME,
    Code VARCHAR(10),
    CardType VARCHAR(255),
    CardNumber VARCHAR(20),
    SecurityCode VARCHAR(4),
    CustomerID INT,
    DeliveryPref VARCHAR(255),
    FOREIGN KEY (Code) REFERENCES DiscountCodes(Code),
    FOREIGN KEY (CardType,CardNumber,SecurityCode) REFERENCES PaymentDetails(CardType,CardNumber,SecurityCode),
    FOREIGN KEY (CustomerID) REFERENCES Person(CustomerID)
);

-- Create the BookingTicketType table
CREATE TABLE BookingTicketType (
    BookingRef INT,
    TicketTypeID INT,
    Quantity INT,
    PRIMARY KEY (BookingRef, TicketTypeID),
    FOREIGN KEY (BookingRef) REFERENCES Booking(BookingRef),
    FOREIGN KEY (TicketTypeID) REFERENCES TicketType(TicketTypeID)
);

-- Sample data for the Person table
INSERT INTO Person (CustomerID, Fname, Sname, Address, DateOfBirth)
VALUES
    (1, 'Ian', 'Cooper', '789 Elm St', '1980-04-15'),
    (2, 'Joe', 'Smith', '987 Oak Ave', '1995-12-20');
    
-- Sample data for the PaymentDetails table
INSERT INTO PaymentDetails (CardType, CardNumber, SecurityCode, ExpiryDate, CustomerID)
VALUES
    ('Visa', '1234567890123456', '123', '2025-12-31', 1),
    ('MasterCard', '9876543210987654', '456', '2024-10-31', 2);

-- Sample data for the Event table
INSERT INTO Event (EventID, EventName, Date, StartTime, EndTime, VenueName, Postcode,City, Address,VenueCapacity,Details)
VALUES
    (1, 'Exeter Food Festival 2023', '2023-07-05', '10:00:00', '15:00:00', 'Exeter Park', 'EX12AB','Exeter', '123 Main St', 5000,'The annual food festival in exeter'),
    (2, 'Exmouth Music Festival 2023', '2023-08-15', '12:00:00', '15:00:00', 'Exmouth Arena', 'EX34CD','Exmouth', '456 Park Ave', 8000,'Exmouths biggest music festival'),
    (3, 'Exeter Fight Night', '2023-08-15', '12:00:00', '15:00:00', 'Exeter Castle', 'EX4 7EW', 'Exeter','12 main street', 6000,'The best fight night in the country');
-- Sample data for the DiscountCodes table
INSERT INTO DiscountCodes (Code, DiscountAmount, ExpirationDate, EventID)
VALUES
    ('FOOD10', 0.10, '2023-07-10', 1),
    ('SUMMER', 0.20, '2023-08-31', 2);

-- Sample data for the TicketType table
INSERT INTO TicketType (TicketTypeID, Price, TicketType, MaxAmount, EventID)
VALUES
    (1, 50.00, 'Adult', 1000, 1),
    (2, 25.00, 'Child', 800, 1),
    (3, 100.00, 'Gold', 500, 2),
    (4, 75.00, 'Silver', 1000, 2),
    (5, 50.00, 'Bronze', 1500, 2),
    (6, 50.00, 'Adult', 10, 3);
    
-- Sample data for the Booking table
INSERT INTO Booking (BookingRef, TotalCost, BookingDate,BookingTime, Code, CardType, CardNumber, SecurityCode, CustomerID, DeliveryPref)
VALUES
    (101, 135.00, '2023-07-05','12:27:00', 'FOOD10', 'Visa', '1234567890123456', '123', 1, 'Email'),
    (102, 195.00, '2023-08-15', '14:15:00', 'SUMMER','MasterCard', '9876543210987654', '456', 2, 'Mail'),
	(103, 195.00, '2023-08-15', '14:15:00', null,'MasterCard', '9876543210987654', '456', 2, 'Mail');
    
-- Sample data for the BookingTicketType table
INSERT INTO BookingTicketType (BookingRef, TicketTypeID, Quantity)
VALUES
    (101, 1, 2),
    (101, 2, 1),
    (102, 3, 2),
    (103,6,10),
    (102, 4, 3);


