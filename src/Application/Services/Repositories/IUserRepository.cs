using Core.Repositories.Interfaces;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
}
