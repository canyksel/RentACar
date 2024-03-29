using Application.Features.Fuels.Commands.CreateFuel;
using Application.Features.Fuels.Commands.DeleteFuel;
using Application.Features.Fuels.Commands.UpdateFuel;
using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Models;
using Application.Features.Fuels.Queries.GetByIdFuel;
using Application.Features.Fuels.Queries.GetListFuel;
using Application.Features.Fuels.Queries.GetListFuelByDynamic;
using Application.Requests;
using Core.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FuelsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdFuelQuery getByIdFuelQuery)
    {
        FuelGetByIdDto fuelGetByIdDto = await Mediator.Send(getByIdFuelQuery);
        return Ok(fuelGetByIdDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFuelQuery getListFuelQuery = new() { PageRequest = pageRequest };
        FuelListModel result = await Mediator.Send(getListFuelQuery);

        return Ok(result);
    }

    [HttpGet("Getlist/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, Dynamic dynamic)
    {
        GetListFuelByDynamicQuery getListFuelByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
        FuelListModel result = await Mediator.Send(getListFuelByDynamicQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
    {
        CreatedFuelDto result = await Mediator.Send(createFuelCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFuelCommand updateFuelCommand)
    {
        UpdatedFuelDto result = await Mediator.Send(updateFuelCommand);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteFuelCommand deleteFuelCommand)
    {
        DeletedFuelDto result = await Mediator.Send(deleteFuelCommand);
        return NoContent();
    }
}
