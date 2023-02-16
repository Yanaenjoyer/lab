using Microsoft.AspNetCore.Mvc;
using System;

namespace practicka_zv.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching","1","1"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<string> Get()
        {
            return Summaries;
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }
        [HttpPut]
        public IActionResult update(int index,string name)
        {
            if(index<0||index>=Summaries.Count)
            {
                    return BadRequest("правильно пиши");

            }
            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete (int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("правильно пиши");

            }
            Summaries.RemoveAt(index);
            return Ok();
        }


        [HttpGet("{index}")]
        public IActionResult PoiskPoindeksy(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("правильно пиши");

            }   
            return Ok(Summaries[index]);
        }


        [HttpGet("find-by-name")]
        public int Sumbyname(string name)
        {
            int sum = 0;
            return Summaries.Where(p => name == p).Count();

            //Summaries.Where(p=>p.Contains("l")).Select(p => p.Replace(".",","));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll(int? strategy)    
        {
            if(strategy == null)
            {
                return Ok(Summaries);
            }
            if(strategy == 1)
            {
                return Ok(Summaries.OrderBy(x => x));
            }
            if(strategy == -1)
            {
                return Ok(Summaries.OrderByDescending(x => x));
                
            }
          else
            {
                return BadRequest("Ќекорректное значение параметра sortStrategy");
            }
        }

    }
}