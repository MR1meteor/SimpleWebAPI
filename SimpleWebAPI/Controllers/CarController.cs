using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;
using SimpleWebAPI.Services.CarService;

namespace SimpleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Car>>> GetAll()
        {
            return Ok(await _carService.GetAllCars());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Car>> GetById(int carId)
        {
            var response = await _carService.GetCarById(carId);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpGet("GetCarsPage")]
        public async Task<ActionResult<List<Car>>> GetPage(int amount, int page)
        {
            var response = await _carService.GetCarsPage(amount, page);

            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            
            return Ok(await _carService.AddCar(car));
        }

        [HttpPut]
        public async Task<ActionResult<Car>> UpdateCar(Car car)
        {
            var response = await _carService.UpdateCar(car);

            if (response == null)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var response = await _carService.DeleteCar(id);

            if (response == null)
                return BadRequest();
            
            return Ok(response);
        }
    }
}
