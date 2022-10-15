using Microsoft.AspNetCore.Mvc;
using SimpleWebAPI.Models;

namespace SimpleWebAPI.Services.CarService
{
    public class CarService : ICarService
    {
        private readonly DataContext _context;
        public CarService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetCarById(int carId)
        {
            var dbCar = await _context.Cars.FindAsync(carId);

            if (dbCar == null)
                return null;

            return dbCar;
        }

        public async Task<List<Car>> GetCarsPage(int amount, int page)
        {
            amount = amount <= 0 ? 5 : amount;
            page = page <= 0 ? 1 : page;

            int carsAmount = await _context.Cars.CountAsync();
            bool hasRemainder = carsAmount % amount > 0;

            if (carsAmount / amount + Convert.ToInt32(hasRemainder) < page)
                return null;

            return await _context.Cars.Skip(amount * (page - 1)).Take(amount).ToListAsync();
        }

        public async Task<Car> AddCar(Car newCar)
        {
            newCar.ID = 0;

            _context.Cars.Add(newCar);
            await _context.SaveChangesAsync();

            return newCar;
        }

        public async Task<Car> UpdateCar(Car car)
        {
            var dbCar = await _context.Cars.FindAsync(car.ID);

            if (dbCar == null)
                return null;

            dbCar.Brand = car.Brand;
            dbCar.GearboxType = car.GearboxType;
            dbCar.Drivetrain = car.Drivetrain;
            dbCar.FuelType = car.FuelType;
            dbCar.Year = car.Year;
            dbCar.Price = car.Price;

            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> DeleteCar(int id)
        {
            var dbCar = await _context.Cars.FindAsync(id);

            if (dbCar == null)
                return null;

            _context.Remove(dbCar);
            await _context.SaveChangesAsync();

            return dbCar;
        }
    }
}
