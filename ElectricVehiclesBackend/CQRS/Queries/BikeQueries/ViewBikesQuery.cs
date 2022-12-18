﻿using Entities;
using MediatR;
using System.Net;

namespace CQRS.Queries.BikeQueries
{
    public class ViewBikesQuery : IRequest<IEnumerable<Bike>>
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}