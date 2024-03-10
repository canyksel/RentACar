using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.Users.Rules;

public class UserBusinessRoles
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRoles(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        if (user is not null) throw new BusinessException("User email already exists.");
    }

    public async Task UserShouldExistsWhenRequested(User user)
    {
        if (user is null) throw new BusinessException("User does not exists.");
    }
}
