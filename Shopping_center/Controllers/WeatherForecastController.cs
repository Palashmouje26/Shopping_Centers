using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shopping_center.Models;
using Shopping_center.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping_center.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       private  IProductDataRepository _dbContext;

        public WeatherForecastController(IProductDataRepository dbcontext)
        {
            _dbContext = dbcontext;
        }

        //[HttpPost]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    //_dbContext.Products.Add(products);
        //    //await _dbContext.SaveChangesAsync();
        //    //return CreatedAtAction("GetProducts", new { id = products.PId }, products);

        //}
    }
}
