using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Interfaces;
using CoreBank.Dtos;
using DataAccessLayer.Models;

namespace CoreBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IService<User> _userService;

        public UsersController(IService<User> userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return _userService.GetAll().Select(x => x.Username).ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return _userService.Get(x => x.UserId == id).Username;
                //return "value" + id;
        }

        // POST api/users
        [HttpPost]
        public void Post(UserDto userDto)
        {
            var user = new User
            {
                UserId = userDto.Id,
                AccountNumber = userDto.AccountNumber,
                BankNumber = userDto.BankNumber,
                Username = userDto.Username

            };

            _userService.Add(user);
        }

        // PUT api/users/id
        [HttpPut("{id}")]
        public void Put(int id, UserDto userDto)
        {
            var user = _userService.Get(x => x.UserId == id);

            if (user != null)
            {
                user.AccountNumber = userDto.AccountNumber;
                user.BankNumber = userDto.BankNumber;
                user.Username = userDto.Username;
            }

            _userService.Update(user);
        }

        // DELETE api/users/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = _userService.Get(x => x.UserId == id);

            if (user != null)
            {
                _userService.Remove(user);
            }
        }
    }
}
