using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowroomService.Model
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public decimal ZeroToSixty { get; set; }
        public int Price { get; set; }
    }
}
