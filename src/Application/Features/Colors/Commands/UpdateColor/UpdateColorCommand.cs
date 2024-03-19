using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.UpdateColor
{
    public class UpdateColorCommand : IRequest<UpdatedColorDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, UpdatedColorDto>
        {
            private readonly IColorRepository _colorRepository;
            private readonly IMapper _mapper;
            private readonly ColorBusinessRules _colorBusinessRules;

            public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper, ColorBusinessRules colorBusinessRules)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
                _colorBusinessRules = colorBusinessRules;
            }

            public async Task<UpdatedColorDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                Color? color = await _colorRepository.GetAsync(c => c.Id == request.Id);

                _colorBusinessRules.ColorShouldExistsWhenRequested(color);

                Color mappedColor = _mapper.Map<Color>(color);
                Color updatedColor = await _colorRepository.UpdateAsync(mappedColor);
                UpdatedColorDto updatedColorDto = _mapper.Map<UpdatedColorDto>(updatedColor);

                return updatedColorDto;
            }
        }
    }
}
