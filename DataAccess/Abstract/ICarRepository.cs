using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;
//using Entities.Abstract;

namespace DataAccess.Abstract
{
    public interface ICarRepository : IEntityRepository<Car>
    {
        
    }
}
