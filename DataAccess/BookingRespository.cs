using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayInnReadModels;
using HolidayInnReadModels.Models;

namespace DataAccess
{
    public class BookingRepository: IBookingRepository
    {
        public int CreateBooking(Guid id, string name, string phone, string email, DateTime checkInDate, DateTime checkOutDate)
        {
            
            string sql = @"dbo.Booking_Insert @Id, @Name, @Phone, @Email, @CheckInDate, @CheckOutDate";

            return SqlDataAccess.SaveData(sql, new {Id = id, Name = name, Phone = phone, Email = email, CheckInDate = checkInDate, CheckOutDate = checkOutDate});
        }

        public List<BookingModel> LoadBookings()
        {
            string sql = @"dbo.Booking_SelectAll";

            return SqlDataAccess.LoadData<BookingModel>(sql);
        }

        public BookingModel GetBooking(Guid bookingGuid)
        {
            string sql = @"dbo.Booking_SelectById @BookingGuid";
            return SqlDataAccess.SingleOrDefault<BookingModel>(sql, new { BookingGuid = bookingGuid });
        }

        public int CancelBooking(Guid bookingGuid, DateTime cancelledDate)
        {
            string sql = @"dbo.Booking_CancelById @BookingGuid, @CancelledDate";

            return SqlDataAccess.SaveData(sql, new { BookingGuid = bookingGuid, CancelledDate = cancelledDate });
        }

        public int CheckOut(Guid bookingGuid, DateTime checkedOutDate)
        {
            string sql = @"dbo.Booking_CheckOutById @BookingGuid, @CheckedOutDate";

            return SqlDataAccess.SaveData(sql, new { BookingGuid = bookingGuid, CheckedOutDate = checkedOutDate });
        }
    }
}
