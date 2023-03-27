using BookingGUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Principal;

namespace BookingGUI.Controllers
{
    public class AdminCenter : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "center";
            RestClient restClient = new RestClient("https://localhost:44347/");


            RestRequest restRequest = new RestRequest("api/Centers/", Method.Get);


            RestResponse resp = restClient.Execute(restRequest);


            List<Center> centerDetails = JsonConvert.DeserializeObject<List<Center>>(resp.Content);
            return View(centerDetails);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            RestClient restClient = new RestClient("https://localhost:44347/");

            RestRequest restRequest = new RestRequest("api/Centers/" + id);


            RestResponse resp = restClient.Delete(restRequest);


            Center Details = JsonConvert.DeserializeObject<Center>(resp.Content);
            if (Details != null)
            {
                return Ok(Details);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IActionResult Update(int id, Center center)
        {
            RestClient restClient = new RestClient("https://localhost:44347/");
            RestRequest restRequest = new RestRequest("api/Accounts/{id}", Method.Put);
            restRequest.AddUrlSegment("id", id);
            restRequest.AddJsonBody(JsonConvert.SerializeObject(center));
            RestResponse restResponse = restClient.Execute(restRequest);

            return Ok(restResponse);
        }
    }
}
