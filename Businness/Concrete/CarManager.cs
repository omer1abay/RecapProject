using Businness.Abstract;
using Businness.Constants;
using Businness.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal carDal)
        {
            _iCarDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //validasyon : iş kurallarına uyumluluğun kontrol edilmesi.

            //ValidationTool.Validate(new CarValidator(), car); //AOP ile yaptık..

            _iCarDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> GetById(int carid)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p=> p.BrandId == id), Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == id), Messages.ProductListed);
        }

        public IDataResult<List<CarInfoDto>> GetsCarInfo()
        {
            return new SuccessDataResult<List<CarInfoDto>>(_iCarDal.CarInfos(), Messages.ProductListed);
        }

        public IResult Update(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
