using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomController : ControllerBase
    {
        private IConfiguration configuration;
        private string DbConn = string.Empty;
        public CustomController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        [HttpGet]
        public IActionResult GetCustomContent()
        {
            //Method 1 to fetch the data from appsettings.json
            DbConn = configuration.GetSection("CustomSettings").GetSection("ConnStr").Value.ToString();

            // var data = new List<string>();
            // data.Add("Oliver");
            // data.Add("Berry");
            return Ok(DbConn);
        }
    }
}