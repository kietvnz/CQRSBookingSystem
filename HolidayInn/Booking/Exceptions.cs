using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayInn.Booking
{
    public class BookingNotCreated : Exception
    {
    }
    public class CheckedOutBookingCannotBeCancelled : Exception
    {
    }
    public class CancelledBookingCannotBeCheckedOut : Exception
    {
    }
}
