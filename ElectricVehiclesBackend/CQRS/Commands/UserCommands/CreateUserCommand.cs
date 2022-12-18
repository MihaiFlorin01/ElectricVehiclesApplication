﻿using Common.Enums;

namespace CQRS.Commands.UserCommands
{
    public class CreateUserCommand
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }
}