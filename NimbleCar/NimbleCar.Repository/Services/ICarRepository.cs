using NimbleCar.DataAccess.Entities;

namespace NimbleCar.Repository.Services;

public interface ICarRepository
{
    Task<long> AddAsync(Car car);
    Task<IQueryable<Car>> GetAllAsync();
}