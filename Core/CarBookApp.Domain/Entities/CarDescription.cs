using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Domain.Entities
{
    public class CarDescription
    {
        public int Id { get; set; }
        public required int CarId { get; set; }
        public required Car Car { get; set; }
        public required string Detail { get; set; }
    }
}
