using BookingGUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace BookingGUI.Controllers
{
    public class Bookings : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddBooking(Booking booking)
        {
            RestClient restClient = new RestClient("https://localhost:44347/");
            RestRequest restRequest = new RestRequest("api/Bookings", Method.Post);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(booking));
            RestResponse restResponse = restClient.Execute(restRequest);

            Booking returnDetails = JsonConvert.DeserializeObject<Booking>(restResponse.Content);
            if (returnDetails != null)
            {
                return Ok(returnDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public DateTime[] GetDatesBetween(string name)
        {
            RestClient restClient = new RestClient("https://localhost:44347/");
            RestRequest restRequest = new RestRequest("api/BookedDates/{name}", Method.Get);
            restRequest.AddUrlSegment("name", name);
            RestResponse restResponse = restClient.Execute(restRequest);

            List<DateTime> dates= JsonConvert.DeserializeObject<List<DateTime>>(restResponse.Content);

            DateTime[] dates1 = dates.ToArray();

            return dates1;
        }
    }
}
