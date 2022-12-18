﻿using Abstractions;

namespace Entities
{
    public class BikeType : BaseEntityModel
    {
        public string? Description { get; set; }
        public decimal PricePerMinute { get; set; }
    }
}
