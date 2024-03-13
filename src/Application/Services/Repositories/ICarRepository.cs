using Core.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car>, IRepository<Car>
{
}
