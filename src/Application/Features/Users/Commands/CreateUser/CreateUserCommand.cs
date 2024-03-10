using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<CreatedUserDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Status { get; set; }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserBusinessRoles _userBusinessRoles;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, UserBusinessRoles userBusinessRoles, IMapper mapper)
        {
            _userRepository = userRepository;
            _userBusinessRoles = userBusinessRoles;
            _mapper = mapper;
        }

        public async Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userBusinessRoles.UserEmailCanNotBeDuplicatedWhenInserted(request.Email);

            User mappedUser = _mapper.Map<User>(request);
            User createdUser = await _userRepository.AddAsync(mappedUser);
            CreatedUserDto createdUserDto = _mapper.Map<CreatedUserDto>(createdUser);

            return createdUserDto;
        }
    }
}
