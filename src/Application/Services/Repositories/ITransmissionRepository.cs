using Core.Repositories.Interfaces;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ITransmissionRepository : IRepository<Transmission>, IAsyncRepository<Transmission>
{
}
