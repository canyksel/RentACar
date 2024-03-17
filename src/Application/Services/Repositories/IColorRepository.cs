using Core.Repositories.Interfaces;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IColorRepository : IRepository<Color>, IAsyncRepository<Color>
{
}
