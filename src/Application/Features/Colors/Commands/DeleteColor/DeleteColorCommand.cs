using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colors.Commands.DeleteColor;

public class DeleteColorCommand : IRequest<DeletedColorDto>
{
    public int Id { get; set; }

    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, DeletedColorDto>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        private readonly ColorBusinessRules _colorBusinessRules;

        public DeleteColorCommandHandler(IColorRepository colorRepository, IMapper mapper, ColorBusinessRules colorBusinessRules)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
            _colorBusinessRules = colorBusinessRules;
        }

        public async Task<DeletedColorDto> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            Color? color = await _colorRepository.GetAsync(c => c.Id == request.Id);

            //_colorBusinessRules.ColorShouldExistsWhenRequested(color);

            Color mappedColor = _mapper.Map<Color>(color);
            Color deletedColor = await _colorRepository.DeleteAsync(mappedColor);
            DeletedColorDto deletedColorDto = _mapper.Map<DeletedColorDto>(deletedColor);

            return deletedColorDto;
        }
    }
}
