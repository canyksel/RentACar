using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetModels([FromQuery] PageRequest pageRequest)
        {
            await Mediator.Send(pageRequest);

            GetListModelQuery getListModelQuery = new() { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(getListModelQuery);
            return Ok(result);
        }
    }
}
