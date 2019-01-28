CREATE PROCEDURE [dbo].[Booking_SelectAll]
AS
	Select 
		Id,
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
    from dbo.Booking (nolock);

RETURN 0
