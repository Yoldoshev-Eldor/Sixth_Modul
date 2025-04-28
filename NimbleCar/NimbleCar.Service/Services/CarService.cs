using NimbleCar.DataAccess.Entities;
using NimbleCar.Repository.Services;

namespace NimbleCar.Service.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }
    public async Task<long> AddAsync(Car car)
    {
        if (car == null)
            throw new ArgumentNullException(nameof(car));

        var result = await _carRepository.AddAsync(car);
        return result;
    }

    public async Task<IQueryable<Car>> GetAllAsync()
    {
        return await _carRepository.GetAllAsync();
    }
}
