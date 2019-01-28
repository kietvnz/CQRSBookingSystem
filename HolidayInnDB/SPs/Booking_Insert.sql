CREATE PROCEDURE [dbo].[Booking_Insert]
	@Id UniqueIdentifier,
	@Name nvarchar(50),
	@Phone nvarchar(50),
	@Email nvarchar(100),
	@CheckInDate DateTime,
	@CheckOutDate DateTime
AS
	Insert into dbo.Booking (BookingGuid, Name, Phone, Email, CheckInDate, CheckOutDate) 
    values (@Id, @Name, @Phone, @Email, @CheckInDate, @CheckOutDate);

RETURN 0
