using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, SQLServerContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (SQLServerContext context =new SQLServerContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join x in context.Colors on c.ColorId equals x.Id
                             select new CarDetailDto {CarId=c.Id,CarName=c.Name,BrandName=b.Name,ColorName=x.Name,Description=c.Description,DailyPrice=c.DailyPrice,ModelYear=c.ModelYear};
                return result.ToList();
            }
        }
    }
}
