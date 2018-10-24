using BusinessLogic.Interfaces;
using CoreBank.Dtos;
using CoreBank.Factories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace CoreBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserAccountsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/userAccounts/accountNumber
        [HttpGet("{accountNumber}")]
        public ActionResult GetUsersAccount(int accountNumber)
        {
            var userFactory = new UserFactory(_userService);
            var validationErrors = userFactory.ValidateRequest(accountNumber.ToString());

            if (validationErrors.Count <= 0)
            {
                var webResponse = _userService.GetAPIStreamReader(string.Format("http://bizfibank-bizfitech.azurewebsites.net/api/v1/accounts/{0}", accountNumber));
                var response = new UserAccountDto();

                if (webResponse.StatusCode.Equals(HttpStatusCode.OK))
                    using (Stream accessTokenWebResponseStream = webResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(accessTokenWebResponseStream))
                        {
                            response = JsonConvert.DeserializeObject<UserAccountDto>(reader.ReadToEnd().Replace("_", ""));
                        }
                    }

                return Ok(response);
            }

            return BadRequest(validationErrors);
        }
    }
}
