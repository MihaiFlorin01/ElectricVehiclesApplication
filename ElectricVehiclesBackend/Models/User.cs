﻿using Abstractions;
using Common.Enums;

namespace Models
{
    public class User : BaseEntityModel
    {
        public string? Email { get; set; }
        public string? Password { get; set; }       
        public UserRole Role { get; set; }
    }
}
