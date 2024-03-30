using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.UpdateModel;

public class UpdateModelCommand : IRequest<UpdatedModelDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public decimal DailyPrice { get; set; }
    public string ImageUrl { get; set; }

    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdatedModelDto>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        private readonly ModelBusinessRules _modelBusinessRules;

        public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<UpdatedModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            Model? model = await _modelRepository.GetAsync(m => m.Id == request.Id);

            await _modelBusinessRules.ModelNameWithSameBrandCanNotBeDuplicatedWhenUpdated(request.Id, request.Name, request.BrandId);

            Model mappedModel = _mapper.Map<Model>(request);
            Model updatedModel = await _modelRepository.UpdateAsync(mappedModel);
            UpdatedModelDto updatedModelDto = _mapper.Map<UpdatedModelDto>(updatedModel);

            return updatedModelDto;
        }
    }
}
