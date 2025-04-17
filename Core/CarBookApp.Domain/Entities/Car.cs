using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public required int BrandId { get; set; }
        public required Brand Brand { get; set; }
        public required string Model { get; set; }
        public required string CoveredImageUrl { get; set; }
        public required int Km { get; set; }
        public required string Transmission { get; set; }
        public required int Seat { get; set; }
        public required int Luggage { get; set; }
        public required string FuelType { get; set; }
        public required string BigImageUrl { get; set; }
        public List<CarFeature> CarFeatures { get; set; } = [];
        public List<CarDescription> CarDescriptions { get; set; } = [];
        public List<CarPricing> CarPricings { get; set; } = [];
    }
}
