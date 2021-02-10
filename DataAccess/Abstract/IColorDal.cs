using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
        List<Color> GetAll(Expression<Func<Color, bool>> filter = null) ;
        Color Get(Expression<Func<Color, bool>> filter) ;
        void Add(Color color) ;
        void Delete(Color color);
        void Update(Color color);
    }
}
