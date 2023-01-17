using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepository<Car, CarDbContext>, ICarDal
    {
        public List<CarInfoDto> CarInfos()
        {
            using (CarDbContext context = new CarDbContext())
            {
                var info = from p in context.Cars
                           join b in context.Brands 
                           on p.BrandId equals b.BrandId
                           join c in context.Colors 
                           on p.ColorId equals c.ColorId
                           select new CarInfoDto { ColorName = c.ColorName, BrandName = b.BrandName, CarName = p.Description, DailyPrice = p.DailyPrice };

                return info.ToList();

            }
        }
    }
}
