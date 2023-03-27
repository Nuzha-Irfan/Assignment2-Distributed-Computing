using BookingGUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace BookingGUI.Controllers
{
    public class centerManage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertCenters(Center center)
        {
            RestClient restClient = new RestClient("https://localhost:44347/");
            RestRequest restRequest = new RestRequest("api/Centers", Method.Post);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(center));
            RestResponse restResponse = restClient.Execute(restRequest);

            Center returnDetails = JsonConvert.DeserializeObject<Center>(restResponse.Content);
            if (returnDetails != null)
            {
                return Ok(returnDetails);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
