using Application.Features.Fuels.Models;
using Application.Requests;
using Application.Services.Repositories;
using AutoMapper;
using Core.Dynamic;
using Core.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Fuels.Queries.GetListFuelByDynamic;

public class GetListFuelByDynamicQuery : IRequest<FuelListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListFuelByDynamicQueryHandler : IRequestHandler<GetListFuelByDynamicQuery, FuelListModel>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public GetListFuelByDynamicQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<FuelListModel> Handle(GetListFuelByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Fuel> fuels = await _fuelRepository
                .GetListByDynamicAsync(request.Dynamic,
                                       index: request.PageRequest.Page,
                                       size: request.PageRequest.PageSize);

            FuelListModel fuelListModel = _mapper.Map<FuelListModel>(fuels);

            return fuelListModel;
        }
    }
}
