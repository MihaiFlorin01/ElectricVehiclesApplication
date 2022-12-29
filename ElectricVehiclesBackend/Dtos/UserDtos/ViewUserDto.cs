﻿using Utils.Enums;

namespace Dtos.UserDtos
{
    public class ViewUserDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
    }
}
