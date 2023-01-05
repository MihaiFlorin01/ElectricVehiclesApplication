﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.VehicleCommands
{
    public class DeleteVehicleCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
