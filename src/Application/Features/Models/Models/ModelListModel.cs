using Application.Features.Models.Dtos;
using Core.Paging;

namespace Application.Features.Models.Models;

public class ModelListModel : BasePageableModel
{
    public IList<ModelListDto> Items { get; set; }
}
