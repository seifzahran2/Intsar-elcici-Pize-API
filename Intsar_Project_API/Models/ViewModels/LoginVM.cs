﻿using System.ComponentModel.DataAnnotations;

namespace Intsar_Project_API.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
