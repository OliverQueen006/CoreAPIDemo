using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    // [ApiController]
    [Route("api/[controller]")]
    public class CustomController : ControllerBase
    {
        private IConfiguration configuration;
        private string DbConn = string.Empty;
        private IOptions<CustomSettingModel> appsettings;

        public CustomController(IConfiguration iConfig,IOptions<CustomSettingModel> iOptions)
        {
            appsettings = iOptions;
            configuration = iConfig;
        }

        [HttpGet]
        public IActionResult GetCustomContent()
        {
            //Method 1 to fetch the data from appsettings.json
            //DbConn = configuration.GetSection("CustomSettings").GetSection("ConnStr").Value.ToString();

            //Method 2 to fetch the data from appsettings.json
            //Here we are using Model class to fetch the record because we are loading the whole configuration settings everytime 
            //when our controller is called. So, We create one model with the same properties of our appsettings.json.
            //Then we bind our model with our appsettings.json properties under Startup.cs file (which is I think DI kind of thing.)
            //So, our settings will be load when our application will start (which is what i am thinking.)
            //And now here in out custom controller we will use that properties using IOptions interface.
            DbConn = appsettings.Value.ConnStr;

            // var data = new List<string>();
            // data.Add("Oliver");
            // data.Add("Berry");
            return Ok(DbConn);
        }
    }
}