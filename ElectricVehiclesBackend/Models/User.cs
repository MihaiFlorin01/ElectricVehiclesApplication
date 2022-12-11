﻿using Abstractions;
using Common.Enums;

namespace Models
{
    public class User : BaseEntityModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }       
        public UserRole Role { get; set; }
    }
}
