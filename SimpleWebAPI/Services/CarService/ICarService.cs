using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Services.CarService
{
    public interface ICarService
    {
        Task<List<Car>> GetAllCars();
        Task<Car> GetCarById(int carId);
        Task<List<Car>> GetCarsPage(int amount, int page);
        Task<Car> AddCar(Car newCar);
        Task<Car> UpdateCar(Car newCar);
        Task<Car> DeleteCar(int id);
    }
}
