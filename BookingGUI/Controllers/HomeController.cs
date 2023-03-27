using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using RestSharp;
using Newtonsoft.Json;
using Assignment2.Models;

namespace BookingGUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.Title = "Home";
           
            return View();


        }

        
    }
}
