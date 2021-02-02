using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        void Delete(int id);
        void Update(Car car);
        Car GetById(int id);
    }
}
