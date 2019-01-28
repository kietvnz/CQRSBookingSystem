using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edument.CQRS;
using Events.Booking;
using System.Collections;

namespace HolidayInn.Booking
{
    public class BookingAggregate : Aggregate,
        IHandleCommand<CreateBooking>,
        IHandleCommand<CancelBooking>,
        IHandleCommand<CheckOutBooking>,
        IApplyEvent<BookingCreated>,
        IApplyEvent<BookingCancelled>,
        IApplyEvent<BookingCheckedOut>
    {
        private bool created;
        private bool cancelled;
        private bool checkedOut;

        public IEnumerable Handle(CreateBooking b)
        {
            yield return new BookingCreated
            {
                Id = b.Id,
                Name = b.Name,
                Phone = b.Phone,
                Email = b.Email,
                CheckInDate = b.CheckInDate,
                CheckOutDate = b.CheckOutDate
            };
        }

        public IEnumerable Handle(CancelBooking b)
        {
            if (!created)
            {
                throw new BookingNotCreated();
            }

            if (checkedOut)
            {
                throw new CheckedOutBookingCannotBeCancelled();
            }

            yield return new BookingCancelled
            {
                Id = b.Id,
                CancelledDate = b.CancelledDate
            };
        }

        public IEnumerable Handle(CheckOutBooking b)
        {
            if (!created)
            {
                throw new BookingNotCreated();
            }

            if (cancelled)
            {
                throw new CancelledBookingCannotBeCheckedOut();
            }

            yield return new BookingCheckedOut
            {
                Id = b.Id,
                CheckedOutDate = b.CheckedOutDate
            };
        }

        public void Apply(BookingCreated e)
        {
            created = true;
        }

        public void Apply(BookingCancelled e)
        {
            cancelled = true;
        }

        public void Apply(BookingCheckedOut e)
        {
            checkedOut = true;
        }
    }
}
