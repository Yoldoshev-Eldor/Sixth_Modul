using Microsoft.EntityFrameworkCore;
using NimbleCar.DataAccess;
using NimbleCar.DataAccess.Entities;

namespace NimbleCar.Repository.Services;

public class CarRepository : ICarRepository
{
    private readonly MainContext _mainContext;

    public CarRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<long> AddAsync(Car car)
    {
        _mainContext.Cars.Add(car);
        
        await _mainContext.SaveChangesAsync();
        return car.CarID;
    }

    public async Task<IQueryable<Car>> GetAllAsync()
    {
        var cars = _mainContext.Cars;
        return cars;
    }
}
