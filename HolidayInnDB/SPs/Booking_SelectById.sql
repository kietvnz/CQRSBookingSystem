CREATE PROCEDURE [dbo].[Booking_SelectById]
	@BookingGuid UniqueIdentifier
AS
	Select Id,
		BookingGuid,
		Name, 
		Phone, 
		Email, 
		CheckInDate, 
		CheckOutDate, 
		IsCancelled, 
		CancelledDate,
		IsCheckedOut,
		CheckedOutDate
    from dbo.Booking (nolock)
	where BookingGuid = @BookingGuid;

RETURN 0
