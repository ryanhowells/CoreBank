using BusinessLogic.Interfaces;
using CoreBank.Dtos;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreBank.Factories
{
    public class UserFactory
    {
        private readonly IUserService _userService;

        public UserFactory(IUserService userService)
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
            if (userDto.AccountNumber != 0)
                user.AccountNumber = userDto.AccountNumber;
            if (userDto.BankNumber != 0)
                user.BankNumber = userDto.BankNumber;
            if (!string.IsNullOrEmpty(userDto.Username))
                user.Username = userDto.Username;

            return user;
        }

        public List<string> ValidateUserDto(UserDto userDto)
        {
            var validationErrors = new List<string>();

            if (_userService.GetAll().Select(x => x.AccountNumber).Contains(userDto.AccountNumber))
                validationErrors.Add("Duplicate Account number entered.");

            if (userDto.AccountNumber.ToString().Length > 8)
                validationErrors.Add("Account Number is too long.");

            if (userDto.AccountNumber != 0 && userDto.AccountNumber.ToString().StartsWith("0"))
                validationErrors.Add("Account Number cannot start with 0");

            return validationErrors;
        }

        public List<string> ValidateRequest(string accountNumber)
        {
            var validationErrors = new List<string>();

            if (accountNumber.Length != 8)
                validationErrors.Add("Account Number length is not valid.");
            
            if (accountNumber.StartsWith("0"))
                validationErrors.Add("Account Number cannot start with 0");

            return validationErrors;
        }
    }
}
