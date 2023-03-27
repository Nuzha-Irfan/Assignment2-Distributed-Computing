using BookingGUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Principal;

namespace BookingGUI.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Adminlogin";
            return View();
        }

        
    }
}
