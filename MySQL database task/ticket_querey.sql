-- querey 1
SELECT EventName,StartTime,EndTime,VenueName,TicketType,MaxAmount
FROM Event,TicketType
WHERE Event.EventID =1
AND TicketType.EventID = 1;

-- querey 2
SELECT EventName,StartTime,EndTime,Details
FROM Event
where City = 'Exeter'
And Date BETWEEN '2023-07-01' AND '2023-07-10' ;

-- querey 3
Select MaxAmount 
From TicketType
where EventID = (Select EventID
				From Event
				Where EventName = 'Exmouth Music Festival 2023')
AND TicketType = 'Bronze';

-- querey 4
SELECT P.Fname, P.Sname, SUM(BTT.Quantity) AS NumGoldTickets
FROM Person P
JOIN Booking B ON P.CustomerID = B.CustomerID
JOIN BookingTicketType BTT ON B.BookingRef = BTT.BookingRef
JOIN TicketType TT ON BTT.TicketTypeID = TT.TicketTypeID
JOIN Event E ON TT.EventID = E.EventID
WHERE E.EventName = 'Exmouth Music Festival 2023'
AND TT.TicketType = 'Gold'
GROUP BY P.CustomerID, P.Fname, P.Sname;

-- querey 5 
SELECT E.EventName, IFNULL(SUM(BTT.Quantity), 0) AS NumTicketsSold
FROM Event E
LEFT JOIN TicketType TT ON E.EventID = TT.EventID
LEFT JOIN BookingTicketType BTT ON TT.TicketTypeID = BTT.TicketTypeID
GROUP BY E.EventID, E.EventName
ORDER BY NumTicketsSold DESC;

-- querey 6
SELECT
    B.BookingRef AS BookingID,
    CONCAT(P.Fname, ' ', P.Sname) AS CustomerName,
    B.BookingDate AS BookingDate,
    B.BookingTime AS BookingTime,
    E.EventName AS EventTitle,
    B.DeliveryPref AS DeliveryOption,
    TT.TicketType AS TicketType,
    BTT.Quantity AS NumberOfTickets,
    (TT.Price * BTT.Quantity) AS TotalCost
FROM Booking B
JOIN Person P ON B.CustomerID = P.CustomerID
JOIN BookingTicketType BTT ON B.BookingRef = 101 AND BTT.BookingRef = 101
JOIN TicketType TT ON BTT.TicketTypeID = TT.TicketTypeID
JOIN DiscountCodes DC ON B.Code = DC.Code
JOIN Event E ON DC.EventID = E.EventID
WHERE B.BookingRef = 101;

-- querey 7
SELECT E.EventName AS EventTitle, SUM(TT.Price * BTT.Quantity) AS TotalIncome
FROM Event E
JOIN DiscountCodes DC ON E.EventID = DC.EventID
JOIN TicketType TT ON E.EventID = TT.EventID
JOIN Booking B ON DC.Code = B.Code
JOIN BookingTicketType BTT ON B.BookingRef = BTT.BookingRef AND BTT.TicketTypeID = TT.TicketTypeID
GROUP BY E.EventName
ORDER BY TotalIncome DESC
LIMIT 1;