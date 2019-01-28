using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edument.CQRS;
using HolidayInn.Booking;
using System.Configuration;
using HolidayInnReadModels;
using DataAccess;

namespace BookingSystem
{
    public static class Domain
    {
        public static MessageDispatcher Dispatcher;
        public static IBookingQueries BookingQueries;
        
        public static void Setup()
        {
            Dispatcher = new MessageDispatcher(new SqlEventStore(ConfigurationManager.ConnectionStrings["BookingSystemDB"].ConnectionString));
            Dispatcher.ScanInstance(new BookingAggregate());

            IBookingRepository bookingRepo = new BookingRepository();
            BookingQueries = new Bookings(bookingRepo);

            Dispatcher.ScanInstance(BookingQueries);
        }
    }
}