using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CarImagesController : Controller
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.IsSucccess)
            {
                return Ok();
            }

            return BadRequest();
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.IsSucccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.IsSucccess)
            {
                return Ok(result);
            }
            return Ok(result);



        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] List<IFormFile> formFile, [FromForm] CarImages carImage)
        {

            var result = _carImageService.Add(formFile, carImage);
            if (result.IsSucccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImages carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.IsSucccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] List<IFormFile> file, [FromForm] CarImages carImage)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.IsSucccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
