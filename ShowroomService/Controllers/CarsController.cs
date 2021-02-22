using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowroomService.Model;
using ShowroomService.Repository;

namespace ShowroomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        [Route("{type}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Car>))]
        public ActionResult<IEnumerable<string>> Get(string type)
        {
            var cars = CarRepository.GetCarsOfType(type);

            if (!cars.Any())
            {
                return NotFound();
            }

            return Ok(cars);
        }
    }
}
