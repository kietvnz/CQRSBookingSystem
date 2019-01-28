CREATE PROCEDURE [dbo].[Booking_CancelById]
	@BookingGuid UniqueIdentifier,
	@CancelledDate DateTime
AS
	Update dbo.Booking
	set IsCancelled = 1,
		CancelledDate = @CancelledDate
	where BookingGuid = @BookingGuid
	and IsCheckedOut = 0

RETURN 0
