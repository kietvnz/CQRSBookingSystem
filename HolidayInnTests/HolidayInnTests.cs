using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using HolidayInn.Booking;
using Edument.CQRS;
using Events.Booking;

namespace HolidayInnTests
{
    [TestFixture]
    public class BookingTests : BDDTest<BookingAggregate>
    {
        private Guid testId;

        [SetUp]
        public void Setup()
        {
            testId = Guid.NewGuid();
        }

        [Test]
        public void CreateABooking()
        {
            Test(
                Given(),
                When(new CreateBooking
                {
                    Id = testId,
                    Name = "John",
                    Phone = "0211234567",
                    Email = "test@test.com",
                    CheckInDate = DateTime.Parse("2019-01-27 14:00"),
                    CheckOutDate = DateTime.Parse("2019-01-28 14:00")
                }),
                Then(new BookingCreated
                {
                    Id = testId,
                    Name = "John",
                    Phone = "0211234567",
                    Email = "test@test.com",
                    CheckInDate = DateTime.Parse("2019-01-27 14:00"),
                    CheckOutDate = DateTime.Parse("2019-01-28 14:00")
                }));
        }

        [Test]
        public void CannotCancelABookingWithoutBookingCreated()
        {
            Test(
                Given(),
                When(new CancelBooking
                {
                    Id = testId
                }),
                ThenFailWith<BookingNotCreated>());
        }

        [Test]
        public void CannotCheckOutABookingWithoutBookingCreated()
        {
            Test(
                Given(),
                When(new CheckOutBooking
                {
                    Id = testId
                }),
                ThenFailWith<BookingNotCreated>());
        }

        [Test]
        public void CanCancelABooking()
        {
            Test(
                Given(new BookingCreated
                {
                    Id = testId,
                    Name = "John",
                    Phone = "0211234567",
                    Email = "test@test.com",
                    CheckInDate = DateTime.Parse("2019-01-27 14:00"),
                    CheckOutDate = DateTime.Parse("2019-01-28 14:00")
                }),
                When(new CancelBooking
                {
                    Id = testId,
                    CancelledDate = DateTime.Parse("2019-01-01 10:00")
                }),
                Then(new BookingCancelled {
                    Id = testId,
                    CancelledDate = DateTime.Parse("2019-01-01 10:00")
                }));
        }

        [Test]
        public void CanCheckOut()
        {
            Test(
                Given(new BookingCreated
                {
                    Id = testId,
                    Name = "John",
                    Phone = "0211234567",
                    Email = "test@test.com",
                    CheckInDate = DateTime.Parse("2019-01-27 14:00"),
                    CheckOutDate = DateTime.Parse("2019-01-28 14:00")
                }),
                When(new CheckOutBooking
                {
                    Id = testId,
                    CheckedOutDate = DateTime.Parse("2019-01-01 10:00")
                }),
                Then(new BookingCheckedOut
                {
                    Id = testId,
                    CheckedOutDate = DateTime.Parse("2019-01-01 10:00")
                }));
        }

        [Test]
        public void CannotCancelABookingAfterCheckedOut()
        {
            Test(
                Given(new BookingCreated
                {
                    Id = testId,
                    Name = "John",
                    Phone = "0211234567",
                    Email = "test@test.com",
                    CheckInDate = DateTime.Parse("2019-01-27 14:00"),
                    CheckOutDate = DateTime.Parse("2019-01-28 14:00")
                },
                new BookingCheckedOut
                {
                    Id = testId,
                    CheckedOutDate = DateTime.Parse("2019-01-01 08:00")
                }),
                When(new CancelBooking
                {
                    Id = testId,
                    CancelledDate = DateTime.Parse("2019-01-01 10:00")
                }),
                ThenFailWith<CheckedOutBookingCannotBeCancelled>());
        }

        [Test]
        public void CannotCheckOutABookingAfterCancelled()
        {
            Test(
                Given(new BookingCreated
                {
                    Id = testId,
                    Name = "John",
                    Phone = "0211234567",
                    Email = "test@test.com",
                    CheckInDate = DateTime.Parse("2019-01-27 14:00"),
                    CheckOutDate = DateTime.Parse("2019-01-28 14:00")
                },
                new BookingCancelled
                {
                    Id = testId,
                    CancelledDate = DateTime.Parse("2019-01-01 08:00")
                }),
                When(new CheckOutBooking
                {
                    Id = testId,
                    CheckedOutDate = DateTime.Parse("2019-01-01 10:00")
                }),
                ThenFailWith<CancelledBookingCannotBeCheckedOut>());
        }
    }
}
