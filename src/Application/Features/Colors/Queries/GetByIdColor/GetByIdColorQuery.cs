using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Queries.GetByIdColor;

public class GetByIdColorQuery : IRequest<ColorGetByIdDto>
{
    public int Id { get; set; }

    public class GetByIdColorQueryHandler : IRequestHandler<GetByIdColorQuery, ColorGetByIdDto>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private readonly ColorBusinessRules _colorBusinessRules;

        public GetByIdColorQueryHandler(IColorRepository colorRepository, IMapper mapper, ColorBusinessRules colorBusinessRules)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<ColorGetByIdDto> Handle(GetByIdColorQuery request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(c => c.Id == request.Id);

            _colorBusinessRules.ColorShouldExistsWhenRequested(color);

            ColorGetByIdDto colorGetByIdDto = _mapper.Map<ColorGetByIdDto>(color);
            return colorGetByIdDto;
        }
    }
}
