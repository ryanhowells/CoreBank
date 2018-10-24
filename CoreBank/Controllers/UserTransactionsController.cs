using BusinessLogic.Interfaces;
using CoreBank.Dtos;
using CoreBank.Factories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace CoreBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTransactionsController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserTransactionsController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/UserTransactions/accountNumber
        [HttpGet("{accountNumber}")]
        public ActionResult Get(int accountNumber)
        {
            var userFactory = new UserFactory(_userService);
            var validationErrors = userFactory.ValidateRequest(accountNumber.ToString());

            if (validationErrors.Count <= 0)
            {
                var webResponse = _userService.GetAPIStreamReader(string.Format("http://bizfibank-bizfitech.azurewebsites.net/api/v1/accounts/{0}/transactions", accountNumber));
                var response = new List<UserTransactionDto>();

                if (webResponse.StatusCode.Equals(HttpStatusCode.OK))
                    using (Stream accessTokenWebResponseStream = webResponse.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(accessTokenWebResponseStream))
                        {
                            response = JsonConvert.DeserializeObject<List<UserTransactionDto>>(reader.ReadToEnd().Replace("_", ""));
                        }
                    }

                return Ok(response);
            }

            return BadRequest(validationErrors);
        }
    }
}
