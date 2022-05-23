﻿using System;
using System.Collections.Generic;

namespace Intsar_Project_API.Models
{
    public class AuthVM
    {
        public string Message { get; set; }
        public bool IsAuthed { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpireOn { get; set; }

    }
}