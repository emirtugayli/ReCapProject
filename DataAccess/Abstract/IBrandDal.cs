using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
        void Add(Brand brand);


        void Delete(Brand brand);


         Brand Get(Expression<Func<Brand, bool>> filter);



         List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null);



         void Update(Brand brand);
       
    }
}
