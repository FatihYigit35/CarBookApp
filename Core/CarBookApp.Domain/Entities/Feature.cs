using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Domain.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; } = [];
    }
}
