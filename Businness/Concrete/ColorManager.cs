using Businness.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    class ColorManager : IColorService
    {

        IColorDal _iColorDal;

        public ColorManager(IColorDal colorDal)
        {
            _iColorDal = colorDal;
        }

        public void Add(Color color)
        {
            _iColorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _iColorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _iColorDal.GetAll();
        }

        public void Update(Color color)
        {
            _iColorDal.Update(color);
        }
    }
}
