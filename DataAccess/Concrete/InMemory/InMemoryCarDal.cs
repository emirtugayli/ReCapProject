using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
               new Car{Id=1 , BrandId = 1 , ColorId = 3 , DailyPrice=300000, Description ="BMW i8 - So Fast", ModelYear=2010},
               new Car{Id=2 , BrandId = 2 , ColorId = 5 , DailyPrice=150000, Description ="Range Rover - So Cool", ModelYear=2013},
               new Car{Id=3 , BrandId = 1 , ColorId = 2 , DailyPrice=555000, Description ="BMW C120 - Boyle bi araba var mi bilmiyorum bile" , ModelYear=2021 },
               new Car{Id=4 , BrandId = 3 , ColorId = 1 , DailyPrice=100000, Description ="Porsche X - For hot boys" , ModelYear=2005},
               new Car{Id=5 , BrandId = 3 , ColorId = 1 , DailyPrice=150000, Description ="Porsche Y - For hot girls" , ModelYear=2020}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            var carToGet = _cars.SingleOrDefault(c => c.Id == id);
            return carToGet;
        }

        public void Update(Car car)
        {
            var result = _cars.SingleOrDefault(c => c.Id == car.Id);
            result.Id = car.Id;
            result.ModelYear = car.ModelYear;
            result.Description = car.Description;
            result.DailyPrice = car.DailyPrice;
            result.BrandId = car.BrandId; 
        }
    }
}
