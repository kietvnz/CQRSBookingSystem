using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayInnReadModels.Models;
using Events.Booking;
using Edument.CQRS;

namespace HolidayInnReadModels
{
    public class Bookings: IBookingQueries,
        ISubscribeTo<BookingCreated>,
        ISubscribeTo<BookingCancelled>,
        ISubscribeTo<BookingCheckedOut>
    {
        private readonly IBookingRepository bookingRepo;
        public Bookings(IBookingRepository bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }
        public List<BookingModel> LoadBookings()
        {
            return this.bookingRepo.LoadBookings();
        }

        public BookingModel GetBooking(Guid id)
        {
            return this.bookingRepo.GetBooking(id);
        }

        public void Handle(BookingCreated e)
        {
            this.bookingRepo.CreateBooking(e.Id, e.Name, e.Phone, e.Email, e.CheckInDate, e.CheckOutDate);
        }

        public void Handle(BookingCancelled e)
        {
            this.bookingRepo.CancelBooking(e.Id);
        }

        public void Handle(BookingCheckedOut e)
        {
            this.bookingRepo.CheckOut(e.Id);
        }
    }
}
