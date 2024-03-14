using Application.Features.Cars.Commands.CreateCar;
using Application.Features.Cars.Commands.DeleteCar;
using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
        {
            CreatedCarDto result = await Mediator.Send(createCarCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateCarCommand)
        {
            UpdatedCarDto result = await Mediator.Send(updateCarCommand);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand deleteCarCommand)
        {
            DeletedCarDto result = await Mediator.Send(deleteCarCommand);
            return NoContent();
        }
    }
}
