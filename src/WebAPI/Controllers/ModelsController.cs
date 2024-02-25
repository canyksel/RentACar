using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetByIdModel;
using Application.Features.Models.Queries.GetListModel;
using Application.Features.Models.Queries.GetListModelByDynamic;
using Application.Requests;
using Core.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {

            GetListModelQuery getListModelQuery = new() { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdModelQuery getByIdModelQuery)
        {
            ModelGetByIdDto modelGetByIdDto = await Mediator.Send(getByIdModelQuery);
            return Ok(modelGetByIdDto);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {

            GetListModelByDynamicQuery getListModelByDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic};
            ModelListModel result = await Mediator.Send(getListModelByDynamicQuery);
            return Ok(result);
        }
    }
}
