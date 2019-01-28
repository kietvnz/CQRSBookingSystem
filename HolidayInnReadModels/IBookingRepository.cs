using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayInnReadModels.Models;

namespace HolidayInnReadModels
{
    public interface IBookingRepository
    {
        List<BookingModel> LoadBookings();
        BookingModel GetBooking(Guid bookingGuid);
        int CreateBooking(Guid id, string name, string phone, string email, DateTime checkInDate, DateTime checkOutDate);
        int CancelBooking(Guid bookingGuid);
        int CheckOut(Guid bookingGuid);

    }
}
