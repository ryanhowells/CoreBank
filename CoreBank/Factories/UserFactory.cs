using BusinessLogic.Interfaces;
using CoreBank.Dtos;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBank.Factories
{
    public class UserFactory
    {
        private readonly IService<User> _userService;

        public UserFactory(IService<User> userService)
        {
            _userService = userService;
        }

        public User InitialiseUser(UserDto userDto)
        {
            var user = new User
            {
                AccountNumber = userDto.AccountNumber,
                BankNumber = userDto.BankNumber,
                Username = userDto.Username
            };

            return user;
        }

        public User UpdateUserModelFromDto(UserDto userDto, User user)
        {
            user.AccountNumber = userDto.AccountNumber;
            user.BankNumber = userDto.BankNumber;
            user.Username = userDto.Username;

            return user;
        }

        public List<string> Validate(UserDto userDto)
        {
            var validationErrors = new List<string>();

            if (_userService.GetAll().Select(x => x.AccountNumber).Contains(userDto.AccountNumber))
                validationErrors.Add("Duplicate Account number entered.");

            if (userDto.AccountNumber.ToString().Length > 8)
                validationErrors.Add("Account Number is too long.");

            if (userDto.AccountNumber.ToString().StartsWith("0"))
                validationErrors.Add("Account Number cannot start with 0");

            return validationErrors;
        }
    }
}
