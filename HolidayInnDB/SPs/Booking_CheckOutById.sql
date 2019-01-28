CREATE PROCEDURE [dbo].[Booking_CheckOutById]
	@BookingGuid UniqueIdentifier,
	@CheckedOutDate DateTime
AS
	Update dbo.Booking
	set IsCheckedOut = 1,
		CheckedOutDate = @CheckedOutDate
	where BookingGuid = @BookingGuid

RETURN 0
