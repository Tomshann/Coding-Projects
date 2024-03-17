-- Update 1: Increase the amount of Adult tickets for the Exeter Food Festival by 100.
UPDATE TicketType
SET MaxAmount = MaxAmount + 100
WHERE EventID = (SELECT EventID FROM Event WHERE EventName = 'Exeter Food Festival 2023')
AND TicketType = 'Adult';

-- update 2
INSERT INTO Booking (TotalCost, BookingDate,BookingTime, Code, CardType, CardNumber, SecurityCode, CustomerID, DeliveryPref)
SELECT
    (Price * 2 + (SELECT Price FROM TicketType WHERE TicketTypeID = 2)) * 0.9,
    CURDATE(),
    CURTIME(),
    'FOOD10',
    'Visa',
    '1234567890123456',
    '123',
    1,
    'Email'
FROM TicketType
WHERE TicketTypeID = 1;

-- Insert the BookingTicketType records for 2 adults and 1 child ticket
-- Replace with the actual BookingRef from the above booking and TicketTypeIDs.
INSERT INTO BookingTicketType (BookingRef, TicketTypeID, Quantity)
VALUES
    (LAST_INSERT_ID(), 1, 2), -- Use the actual BookingRef from the above booking
    (LAST_INSERT_ID(), 2, 1); -- Use the actual BookingRef from the above booking


-- update 3 
DELETE FROM BookingTicketType WHERE BookingRef = 102;

-- Delete the record from the Booking table
DELETE FROM Booking WHERE BookingRef = 102;

-- update 4
INSERT INTO DiscountCodes (Code, DiscountAmount, ExpirationDate, EventID)
VALUES
    ('SUMMER20', 0.20, '2023-08-31', 2);







