using Core.Repositories.Interfaces;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IBrandRepository : IAsyncRepository<Brand>, IRepository<Brand>
{
}
