using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NimbleCar.DataAccess.Entities;
using NimbleCar.Repository.Services;

namespace NimbleCar.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly ICarRepository _carRepository;

    public CarController(ICarRepository carRepository, ILogger<CarController> logger)
    {
        _carRepository = carRepository;
        _logger = logger;
    }

    [HttpPost("addCar")]
    public async Task<long> AddCarAsync(Car car)
    {
        //_logger.LogInformation("Hello from Add Method worked", DateTime.UtcNow);
        return await _carRepository.AddAsync(car);

    }

    [HttpGet("getAll")]

    public async Task<IQueryable<Car>> GetAllCarAsync()
    {
        //_logger.LogInformation("Hello from GetAll Method worked", DateTime.UtcNow);
        return await _carRepository.GetAllAsync();
    }
}
