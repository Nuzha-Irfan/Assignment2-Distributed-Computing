using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;

namespace Assignment2.Controllers
{
    [RoutePrefix("api/BookedDates")]
    public class BookedDatesController : ApiController
    {

        private CenterBookingEntities1 db = new CenterBookingEntities1();


        // POST api/<controller>
        [Route("{name}")]
        [HttpGet]
        public List <DateTime> Search(string name)
        {
            List<Booking> centers = new List<Booking>();
            List<DateTime> allDates = new List<DateTime>();
            
            try
            {
                // Using SteamReader to read the text file line one-by-one
                centers = db.Bookings.ToList();

                foreach (Booking center in centers)
                {
                    if (String.Equals(center.centerName, name, StringComparison.OrdinalIgnoreCase))
                    {
                       

                        for ( DateTime date = Convert.ToDateTime(center.startDate); date <= center.endDate; date = date.AddDays(1))
                        {
                            allDates.Add(date.Date);

                        }
                           
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading from " + e.StackTrace + "\nMessage = " + e.Message);
            }
            return allDates;
        }

    }
}
