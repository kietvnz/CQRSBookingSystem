using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events.Booking
{
    public class BookingCreated
    {
        public Guid Id;
        public string Name;
        public string Email;
        public string Phone;
        public DateTime CheckInDate;
        public DateTime CheckOutDate;
    }
}
