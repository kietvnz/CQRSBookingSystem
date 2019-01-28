using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayInnReadModels.Models;

namespace HolidayInnReadModels
{
    public interface IBookingQueries
    {
        List<BookingModel> LoadBookings();
        BookingModel GetBooking(Guid id);
    }
}
