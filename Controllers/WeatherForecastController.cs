using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
    

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        { 

            _logger.LogInformation("Logging information.");
            _logger.LogCritical("Logging critical information.");
            _logger.LogDebug("Logging debug information.");
            _logger.LogError("Logging error information.");
            _logger.LogTrace("Logging trace");
            _logger.LogWarning("Logging warning.");


            var rng = new Random();
            return Enumerable.Range(1, 100).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
           

        }

        [HttpGet("{id}")]
        public ActionResult Test(int id)
        {
            var stream = new MemoryStream();

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.GetBuffer())
            };
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = "test.pdf"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var response = Ok(result);

            return response;
        }


        [HttpGet]
        //[Route("api/My/{id:int}")]
        [Route("Get/{a}/{b}")]
        public IEnumerable<Test> Get(int a, string b)   
        {
            return Enumerable.Range(1, 100).Select(index => new Test 
            { 
                value = index ,
                stringValue = b
            }).ToArray();
        }

        [HttpGet("{id}")]
        public long GetTodoItem(long id)
        {
          

            //if (todoItem == null)
            //  {
            //      return NotFound();
            //  }

            return id;
        }



        [HttpPost]
     
        [Route("Get/{a:int}")]
        //[Route("api/My/{a:int}")]
        public int Get(int a)
        {
            return a;
        }


    }

    public class Test
    {
       public int value { get; set; }
       public string stringValue { get; set; }

        public double doubleValue { get; set; }

    }

    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
}
