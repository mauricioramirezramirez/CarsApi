using System;
using Microsoft.AspNetCore.Mvc;
using Cars.Services;
using Cars.Models;

namespace Cars.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CarController:ControllerBase
	{
        private readonly CarsServices _carService;

        public CarController(CarsServices carService)
        {
            this._carService = carService;
        }

        [HttpGet]
        public async Task<List<Car>> Get()
        {
            return await this._carService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Car>> GetById(string id)
        {
            var car = await this._carService.GetById(id);
            if (car is null) return NotFound();

            return car;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Car newCar)
        {
            await _carService.Create(newCar);
            return CreatedAtAction(nameof(Get), new { id = newCar.Id }, newCar);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Car updateCar)
        {
            var car = await this._carService.GetById(id);
            if (car is null) return NotFound();

            updateCar.Id = car.Id;

            await this._carService.Patch(id, updateCar);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var car = await this._carService.GetById(id);
            if (car is null) return NotFound();

            await this._carService.DeleteById(id);

            return NoContent();
        }
    }
}

