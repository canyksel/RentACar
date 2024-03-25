using Core.Repositories.Interfaces;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IFuelRepository : IAsyncRepository<Fuel>, IRepository<Fuel>
{
}
