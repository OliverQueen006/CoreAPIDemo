using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPIDemo.Models;
using WebAPIDemo.Repository;
using WebAPIDemo.Utility;

namespace WebAPIDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IOptions<CustomSettingModel> appSettings;
        public UserController(IOptions<CustomSettingModel> iOptions)
        {
            appSettings = iOptions;
        }

        [HttpGet]
        public ActionResult GetUser()
        {
            var data = DbClientFactory<UserRepository>.Instance.GetAllUser(appSettings.Value.ConnStr.ToString());
            return Ok(data);
        }

        [HttpGet("GetUserByName")]
        public ActionResult GetUserByName([FromQuery]string name)
        {
            var data = DbClientFactory<UserRepository>.Instance.GetUserByName(appSettings.Value.ConnStr, name);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }
        }
    }
}