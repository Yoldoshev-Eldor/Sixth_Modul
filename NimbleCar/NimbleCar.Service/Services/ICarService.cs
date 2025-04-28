using NimbleCar.DataAccess.Entities;

namespace NimbleCar.Service.Services;

public interface ICarService
{
    Task<long> AddAsync(Car car);
    Task<IQueryable<Car>> GetAllAsync();
}