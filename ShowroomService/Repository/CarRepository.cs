using System;
using System.Collections.Generic;
using System.Linq;
using ShowroomService.Model;

namespace ShowroomService.Repository
{
    public static class CarRepository
    {
        private static readonly IEnumerable<Car> Cars = new Car[]
        {
            new Car
            {
                Make = "Ford",
                Model = "Fiesta",
                Year = "2012",
                Type = "Hatchback",
                ZeroToSixty = 23.0m,
                Price = 3000
            },
            new Car
            {
                Make = "Volkswagen",
                Model = "Golf",
                Year = "2015",
                Type = "Hatchback",
                ZeroToSixty = 12.0m,
                Price = 12000
            },
            new Car
            {
                Make = "BMW",
                Model = "3.25i",
                Year = "2013",
                Type = "Saloon",
                ZeroToSixty = 9.5m,
                Price = 15000
            },
            new Car
            {
                Make = "Audi",
                Model = "S4",
                Year = "2015",
                Type = "Saloon",
                ZeroToSixty = 8.3m,
                Price = 17500
            },
            new Car
            {
                Make = "Mercedes",
                Model = "C200",
                Year = "2018",
                Type = "Saloon",
                ZeroToSixty = 8.0m,
                Price = 25000
            },
            new Car
            {
                Make = "Toyota",
                Model = "Land Cruiser",
                Year = "2018",
                Type = "Suv",
                ZeroToSixty = 12.0m,
                Price = 45000
            }
        };

        public static IEnumerable<Car> GetCarsOfType(string type)
        {
            return Cars.Where(car => car.Type.Equals(type, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
