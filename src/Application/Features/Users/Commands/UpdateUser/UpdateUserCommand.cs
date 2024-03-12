using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<UpdatedUserDto>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRules _userBusinessRoles;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRoles, IMapper mapper)
        {
            _userRepository = userRepository;
            _userBusinessRoles = userBusinessRoles;
            _mapper = mapper;
        }

        public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(u => u.Id == request.Id && u.Email == request.Email);

            _userBusinessRoles.UserShouldExistsWhenRequested(user);

            User? mappedUser = _mapper.Map<User>(request);
            User? updatedUser = await _userRepository.UpdateAsync(mappedUser);
            UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(updatedUser);

            return updatedUserDto;
        }
    }
}
