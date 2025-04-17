using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Domain.Entities
{
    public class CarPricing
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CarId { get; set; }
        public required Car Car { get; set; }
        public int PricingId { get; set; }
        public required Pricing Pricing { get; set; }
        public required decimal Amount { get; set; }
    }
}
