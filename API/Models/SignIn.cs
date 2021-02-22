﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class SignIn
    {
        public List<Account> Accounts { get; set; }
        public List<Employee> Employees { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}