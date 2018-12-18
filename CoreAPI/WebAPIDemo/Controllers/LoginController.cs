using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPIDemo.Models;
using WebAPIDemo.Repository;
using WebAPIDemo.Utility;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IOptions<CustomSettingModel> appsettings;

        public LoginController(IOptions<CustomSettingModel> iOptions)
        {
            appsettings = iOptions;
        }

        [HttpPost("chkuser")]
        public ActionResult GetToken(string EmailID, string Password)
        {
            var result = DbClientFactory<LoginRepository>.Instance.CheckUser(appsettings.Value.ConnStr, EmailID, Password);
            if (result != null && Convert.ToBoolean(result))
            {
                //Now Generate Token
                var ClaimData = new[] { new Claim(ClaimTypes.Name, EmailID) };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hitenpandyaisamegastar"));
                var SignCred = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);
                var token = new JwtSecurityToken(
                    claims:ClaimData,
                    signingCredentials:SignCred
                );
                var tokenstr = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(tokenstr);
            }
            else
            {
                //Return message that user is not registered.
                return NotFound("Sorry There is no such user in our database.");
            }
        }
    }
}