using Application.Features.Users.Dtos;

namespace Application.Features.Users.Models;

public class UserListModel
{
    public IList<UserListDto> Items { get; set; }
}
