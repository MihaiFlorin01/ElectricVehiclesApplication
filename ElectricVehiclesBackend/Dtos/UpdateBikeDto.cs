﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class UpdateBikeDto
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
