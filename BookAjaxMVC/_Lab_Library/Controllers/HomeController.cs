using _Lab_Library.Data.Entity;
using _Lab_Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Diagnostics;

namespace _Lab_Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            RestClient client = new RestClient("http://localhost:52772/api/home");
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<List<Author>>(response.Content);
                return Json(result);
            }
            else
            {
                return BadRequest("Bad Request!!!");
            }
        }
        [HttpPost]
        public IActionResult GetBooksByAuthorId(int id)
        {
            RestClient client = new RestClient($"http://localhost:52772/api/home/{id}");
            RestRequest request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<List<Language>>(response.Content);
                return Json(result);
            }
            else
            {
                return BadRequest("Bad Request!!!");
            }
        }
    }
}
