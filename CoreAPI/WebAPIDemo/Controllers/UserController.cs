using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPIDemo.Models;
using WebAPIDemo.Repository;
using WebAPIDemo.Utility;

namespace WebAPIDemo.Controllers
{
    // [Authorize]
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

        [HttpGet("bn")]
        public ActionResult GetUserByName([FromQuery]string name)
        {
            var data = DbClientFactory<UserRepository>.Instance.GetByName(appSettings.Value.ConnStr, name);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public ActionResult AddUser(UserModel usermodel, bool InsertOrUpdate)
        {
            object result = DbClientFactory<UserRepository>.Instance.AddEdit(appSettings.Value.ConnStr, usermodel, InsertOrUpdate);
            if (result != null)
            {
                if (!string.IsNullOrEmpty(result.ToString()) && result.ToString() == "1")
                {
                    return Ok("Operation Successful.");
                }
                return Ok("Some Problem occurs.Please try again later.");
            }
            return BadRequest(result);
        }

        [HttpPost("del")]
        public ActionResult Delete(int UserId)
        {
            object result = DbClientFactory<UserRepository>.Instance.Delete(appSettings.Value.ConnStr, UserId);
            if (result != null)
            {
                if (!string.IsNullOrEmpty(result.ToString()) && result.ToString() == "1")
                {
                    return Ok("Operation Successful.");
                }
                return Ok("Some Problem occurs.Please try again later.");
            }
            return BadRequest(result);
        }
    }
}