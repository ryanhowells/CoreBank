using BusinessLogic.Interfaces;
using CoreBank.Dtos;
using CoreBank.Factories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public ActionResult Get()
        {
            var users = _userService.GetAll().ToList();

            if (users.Count > 0)
                return Ok(users);
            else
                return NotFound("No Users Found.");
        }

        // GET api/users/id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var user = _userService.Get(x => x.UserId == id);

            if (user != null)
                return Ok(user);
            else
                return NotFound(string.Format("User with the Id: {0} Not Found.", id));
        }

        // POST api/users
        [HttpPost]
        public ActionResult Post(UserDto userDto)
        {
            var userFactory = new UserFactory(_userService);
            var validationErrors = userFactory.ValidateUserDto(userDto);

            if (validationErrors.Count <= 0)
            {
                var user = userFactory.InitialiseUser(userDto);
                _userService.Add(user);

                return Ok(user);
            }
            else
                return BadRequest(validationErrors);
        }

        // PUT api/users/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, UserDto userDto)
        {
            var userFactory = new UserFactory(_userService);
            var validationErrors = userFactory.ValidateUserDto(userDto);

            if (validationErrors.Count <= 0)
            {
                var user = _userService.Get(x => x.UserId == id);

                if (user != null)
                {
                    user = userFactory.UpdateUserModelFromDto(userDto, user);
                    _userService.Update(user);

                    return Ok(user);
                }
                else
                    return NotFound(string.Format("User with Id: {0} not found.", id));
            }
            else
                return BadRequest(validationErrors);
        }

        // DELETE api/users/id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userService.Get(x => x.UserId == id);

            if (user != null)
            {
                _userService.Remove(user);

                return Ok(string.Format("User with Id: {0} removed.", id));
            }
            else
                return NotFound(string.Format("User with Id: {0} not found.", id));
        }
    }
}
