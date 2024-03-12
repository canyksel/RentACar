using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<DeletedUserDto>
{
    public int Id { get; set; }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRoles;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRoles, IMapper mapper)
        {
            _userRepository = userRepository;
            _userBusinessRoles = userBusinessRoles;
            _mapper = mapper;
        }

        public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == request.Id);

            _userBusinessRoles.UserShouldExistsWhenRequested(user);

            User? mappedUser = _mapper.Map<User>(request);
            User? deletedUser = await _userRepository.DeleteAsync(mappedUser);
            DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deletedUser);

            return deletedUserDto;
        }
    }
}
