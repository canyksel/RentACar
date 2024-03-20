using Application.Features.Cars.Models;
using Application.Requests;
using Application.Services.Repositories;
using AutoMapper;
using Core.Dynamic;
using Core.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetListCarByDynamic;

public class GetListCarByDynamicQuery : IRequest<CarListModel>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListCarByDynamicQueryHandler : IRequestHandler<GetListCarByDynamicQuery, CarListModel>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListCarByDynamicQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarListModel> Handle(GetListCarByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Car> cars = await _carRepository
                .GetListByDynamicAsync(request.Dynamic,
                                       include: c => c.Include(c => c.Model).Include(c => c.Model.Brand),
                                       index: request.PageRequest.Page,
                                       size: request.PageRequest.PageSize);

            CarListModel mappedCars = _mapper.Map<CarListModel>(cars);
            return mappedCars;
        }
    }
}
