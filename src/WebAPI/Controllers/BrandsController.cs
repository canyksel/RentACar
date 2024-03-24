using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Application.Features.Brands.Queries.GetListBrandByDynamic;
using Application.Requests;
using Core.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery)
    {
        BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdBrandQuery);
        return Ok(brandGetByIdDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
        BrandListModel result = await Mediator.Send(getListBrandQuery);
        return Ok(result);
    }
    [HttpGet("GetList/ByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
    {
        GetListBrandByDynamicQuery getListBrandByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
        BrandListModel result = await Mediator.Send(getListBrandByDynamicQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
        CreatedBrandDto result = await Mediator.Send(createBrandCommand);
        return Created("", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandCommand updateBrandCommand)
    {
        UpdatedBrandDto result = await Mediator.Send(updateBrandCommand);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
    {
        DeletedBrandDto result = await Mediator.Send(deleteBrandCommand);
        return NoContent();
    }
}
