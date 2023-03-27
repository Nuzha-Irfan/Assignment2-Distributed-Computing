using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private CenterBookingEntities1 db = new CenterBookingEntities1();

        [Route("{cname}")]
        [HttpGet]
        public List<Booking> GetCenterBooking(string cname)
        {
           
            List <Booking> bookings = new List<Booking>();
            List<Booking> bookings1 = new List<Booking>();
            bookings=db.Bookings.ToList();
            Booking book = new Booking();
            foreach (Booking booking in bookings)
            {
                if (String.Equals(booking.centerName, cname) )
                {
                    book = booking;
                    bookings1.Add(book);
                }

            }
            return bookings1;
        }
    }
}
