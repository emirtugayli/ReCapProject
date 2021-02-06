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
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand brand)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                var addedBrand = context.Entry(brand);
                addedBrand.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand brand)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                var deletedBrand = context.Entry(brand);
                deletedBrand.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand brand)
        {
            using (SQLServerContext context = new SQLServerContext())
            {
                var UpdatedBrand = context.Entry(brand);
                UpdatedBrand.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
