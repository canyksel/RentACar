using Application.Features.Colors.Models;
using Application.Requests;
using Application.Services.Repositories;
using AutoMapper;
using Core.Dynamic;
using Core.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Queries.GetListColorByDynamic;

public class GetListColorByDynamicQuery : IRequest<ColorListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListColorByDynamicQueryHandler : IRequestHandler<GetListColorByDynamicQuery, ColorListModel>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public GetListColorByDynamicQueryHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<ColorListModel> Handle(GetListColorByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Color> colors = await _colorRepository
                .GetListByDynamicAsync(request.Dynamic,
                                       index: request.PageRequest.Page,
                                       size: request.PageRequest.PageSize);

            ColorListModel mappedColors = _mapper.Map<ColorListModel>(colors);
            return mappedColors;
        }
    }
}
