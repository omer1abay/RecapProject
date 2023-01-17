using Businness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    class BrandManager : IBrandService
    {

        IBrandDal _iBrandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _iBrandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            _iBrandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _iBrandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _iBrandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            _iBrandDal.Update(brand);
        }
    }
}
