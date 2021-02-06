using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car car)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                var addedCar = context.Entry(car);
                if (car.DailyPrice>0 && car.Description.Length>2)
                {
                    addedCar.State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Arabanin günlük fiyatı 0'dan büyük olmalıdır ve Açıklaması en az 2 karakter içermelidir!");
                }
            }
        }

        public void Delete(Car car)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                var deletedCar = context.Entry(car);
                deletedCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Car car)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                var updatedCar = context.Entry(car);
                updatedCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
            
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

      
    }
}
