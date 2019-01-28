using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HolidayInnReadModels.Models
{
    public class BookingModel
    {
        public Guid BookingGuid { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Check-in Date")]
        public DateTime CheckInDate { get; set; }

        [Display(Name = "Check-out Date")]
        public DateTime CheckOutDate { get; set; }

        [Display(Name = "Cancelled")]
        public bool IsCancelled { get; set; }

        [Display(Name = "Cancelled Date")]
        public DateTime? CancelledDate { get; set; }

        [Display(Name = "Checked Out")]
        public bool IsCheckedOut { get; set; }

        [Display(Name = "Checked Out Date")]
        public DateTime? CheckedOutDate { get; set; }
    }
}