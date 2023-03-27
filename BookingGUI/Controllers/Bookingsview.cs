using BookingGUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace BookingGUI.Controllers
{
    public class Bookingsview : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      

        [HttpGet]
        public IActionResult  Searchbyname(string  name)
        {
            RestClient restClient = new RestClient("https://localhost:44347/");


            RestRequest restRequest = new RestRequest("api/search/{cname}", Method.Get);
            restRequest.AddUrlSegment("cname",name);
            RestResponse restResponse = restClient.Execute(restRequest);

            

            return Ok(restResponse.Content);






        }
    }
}
