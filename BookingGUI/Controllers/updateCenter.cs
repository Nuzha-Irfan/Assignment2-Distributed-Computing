using BookingGUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Principal;

namespace BookingGUI.Controllers
{
    public class updateCenter : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Update(int id, Center center)
        {
            RestClient restClient = new RestClient("https://localhost:44347/");
            RestRequest restRequest = new RestRequest("api/Centers/{id}", Method.Put);
            restRequest.AddUrlSegment("id", id);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(center));
            RestResponse restResponse = restClient.Execute(restRequest);

            return Ok(restResponse);
        }
    }
}
