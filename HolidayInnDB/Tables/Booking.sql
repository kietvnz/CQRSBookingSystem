CREATE TABLE [dbo].[Booking]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
    [Phone] NVARCHAR(50) NOT NULL, 
    [CheckInDate] DATETIME NOT NULL, 
    [CheckOutDate] DATETIME NOT NULL, 
    [IsCancelled] BIT NOT NULL DEFAULT(0), 
    [CancelledDate] DATETIME NULL, 
    [IsCheckedOut] BIT NOT NULL DEFAULT 0, 
    [CheckedOutDate] DATETIME NULL, 
    [BookingGuid] UNIQUEIDENTIFIER NOT NULL DEFAULT(newid()) UNIQUE
)
