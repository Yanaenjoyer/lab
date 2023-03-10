using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace zv_practica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        MyDbContext db = new MyDbContext();
        private readonly ILogger<WeatherForecastController> _logger;
        
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpPost("Вывод пользователей")]
        public IActionResult Srch()
        {

            var q = db.Пользователи.Select(p => p);
            return Ok(q);
        }
        [HttpPost("Поиск пользователей по логину")]
        public IActionResult Srchbylogin(int login)
        {
           
     
            var q = db.Пользователи.Where(p=>p.Login == login.ToString());
            return Ok(q);

        }
        [HttpDelete("Удаление пользователей по логину")]
        public IActionResult Deletebylogin(string login)
        {
            Пользователи q = db.Пользователи.Where(p => p.Login == login).Select(p=>p).FirstOrDefault();
            if(q==null)
            {
                return BadRequest();
            }
            db.Пользователи.Remove(q);
            db.SaveChanges();
            return Ok();
           
            
           
        }
        [HttpGet("Добавление пользователя и его адреса")]
        public IActionResult Get(string city,string country,string street,string house,string appartments,bool isdelet,
            int login,int password,string surnm,string name,string lastname,DateTime birthd,bool isdel,bool isadmin) 
        {
            Адрес qw = new Адрес { City = city, Country = country, Street = street, House = house, Appartments = appartments, Login = login.ToString(), IsDeleted = isdelet };
            Пользователи q = new Пользователи { Login = login.ToString(), Password = password.ToString(), Surname = surnm, Name = name, Lastname = lastname, Birthday = birthd, IsDeleted = isdel, IsAdmin = isadmin };
            db.Адрес.Add(qw);
            db.SaveChanges();
            db.Пользователи.Add(q);
            db.SaveChanges();
            return Ok();
        }
    }
}