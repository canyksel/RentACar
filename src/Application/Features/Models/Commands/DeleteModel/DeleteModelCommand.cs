using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.DeleteModel;

public class DeleteModelCommand : IRequest<DeletedModelDto>
{
    public int Id { get; set; }

    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeletedModelDto>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        private readonly ModelBusinessRules _modelBusinessRules;

        public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<DeletedModelDto> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            Model? model = await _modelRepository.GetAsync(m => m.Id == request.Id);
            _modelBusinessRules.ModelShouldExistsWhenRequested(model);
            Model mappedModel = _mapper.Map<Model>(request);
            Model deletedModel = await _modelRepository.DeleteAsync(mappedModel);
            DeletedModelDto deletedModelDto = _mapper.Map<DeletedModelDto>(deletedModel);

            return deletedModelDto;
        }
    }
}
