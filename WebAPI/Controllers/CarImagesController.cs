using Businness.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;
        ICarService _carService;

        public CarImagesController(ICarImagesService carImagesService, ICarService carService)
        {
            _carImagesService = carImagesService;
            _carService = carService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImages images)
        {
            var result = _carImagesService.Add(file,images); 

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPost("car")]
        public IActionResult AddCar(Car car) //api buradaki parametrelere bakarak şablonu anlar
        {
            var result = _carService.Add(car);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm]IFormFile file, [FromForm]CarImages images)
        {
            var result = _carImagesService.Update(file,images);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImages images)
        {
            var result = _carImagesService.Delete(images);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpGet("get")]
        public IActionResult GetById(int carId)
        {
            var result = _carImagesService.GetById(carId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

    }
}
