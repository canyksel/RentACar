using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetByIdModel;

public class GetByIdModelQuery : IRequest<ModelGetByIdDto>
{
    public int Id { get; set; }

    public class GetByIdModelQueryHandler : IRequestHandler<GetByIdModelQuery, ModelGetByIdDto>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetByIdModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ModelGetByIdDto> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
        {
            Model? model = await _modelRepository.GetAsync(m => m.Id == request.Id,
                                                           include: m => m.Include(m => m.Brand).Include(m => m.Fuel));

            var mapped = _mapper.Map<ModelGetByIdDto>(model);

            return mapped;
        }
    }
}
