﻿using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Results.CarResult
{
    public class GetCarQueryResult
    {
        public int Id { get; set; }
        public required int BrandId { get; set; }
        public required string Model { get; set; }
        public required string CoveredImageUrl { get; set; }
        public required int Km { get; set; }
        public required string Transmission { get; set; }
        public required int Seat { get; set; }
        public required int Luggage { get; set; }
        public required string FuelType { get; set; }
        public required string BigImageUrl { get; set; }
    }
}
