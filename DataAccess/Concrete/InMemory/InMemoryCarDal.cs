using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal 
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId = 1, CarId = 1, ColorId = 3, DailyPrice = 150, Description = "audi", ModelYear = 2018},
                new Car{BrandId = 1, CarId = 2, ColorId = 3, DailyPrice = 150, Description = "bmw", ModelYear = 2020},
                new Car{BrandId = 2, CarId = 3, ColorId = 1, DailyPrice = 150, Description = "mercedes", ModelYear = 2022},
                new Car{BrandId = 2, CarId = 4, ColorId = 2, DailyPrice = 150, Description = "chevrolet", ModelYear = 2019},
                new Car{BrandId = 2, CarId = 5, ColorId = 4, DailyPrice = 150, Description = "mazda", ModelYear = 2021},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int car)
        {
            var carToDelete = _cars.SingleOrDefault(p => p.CarId == car);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(Expression<Func<Car, bool>> filter)
        {
            return _cars;
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
