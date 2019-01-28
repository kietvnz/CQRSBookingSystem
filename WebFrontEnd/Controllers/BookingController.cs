using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edument.CQRS;
using HolidayInn.Booking;
using HolidayInnReadModels;
using HolidayInnReadModels.Models;
using System.Configuration;
using AutoMapper;

namespace BookingSystem.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ViewResult Index()
        {
            ViewBag.Message = "Boooking List";
            var data = Domain.BookingQueries.LoadBookings();
            return View(data);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            ViewBag.Message = "Booking Creation";

            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBooking cmd)
        {
            if (ModelState.IsValid)
            {
                cmd.Id = Guid.NewGuid();
                Domain.Dispatcher.SendCommand(cmd);

                return RedirectToAction("Index");
            }

            return View();
        }

        // POST: Booking/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(Guid id)
        {
            if (ModelState.IsValid)
            {
                CancelBooking cmd = new CancelBooking
                {
                    Id = id,
                    CancelledDate = DateTime.Now
                };

                Domain.Dispatcher.SendCommand(cmd);
            }

            return RedirectToAction("Index");
        }

        // POST: Booking/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(Guid id)
        {
            if (ModelState.IsValid)
            {
                CheckOutBooking cmd = new CheckOutBooking
                {
                    Id = id,
                    CheckedOutDate = DateTime.Now
                };

                Domain.Dispatcher.SendCommand(cmd);
            }

            return RedirectToAction("Index");
        }
    }
}
