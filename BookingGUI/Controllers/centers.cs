using BookingGUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Principal;

namespace BookingGUI.Controllers
{
    public class centers : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "center";
            RestClient restClient = new RestClient("https://localhost:44347/");


            RestRequest restRequest = new RestRequest("api/Centers/" , Method.Get);


            RestResponse resp = restClient.Execute(restRequest);


            List<Center> centerDetails = JsonConvert.DeserializeObject<List<Center>>(resp.Content);
            return View(centerDetails);
           
        }

      
    }
}
