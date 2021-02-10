using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<Car> GetAll(Expression<Func<Car, bool>> filter=null);
        Car Get(Expression<Func<Car, bool>> filter);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

        List<CarDetailDto> GetCarDetails();
    }
}
