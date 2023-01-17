using Businness.Abstract;
using Businness.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    public class CarImagesManager : ICarImagesService
    {

        ICarImagesDal _carImagesDal;
        IFileHelper _fileHelper;

        public CarImagesManager(ICarImagesDal carImagesDal, IFileHelper fileHelper)
        {
            _carImagesDal = carImagesDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImages images)
        {
            IResult result = BusinessRules.Run(CheckCountOfCarImages(images.CarId));

            if (result != null)
            {
                return result;
            }

            var image = _fileHelper.AddFile(file, PathConstant.Path);
            images.ImagePath = image;
            images.Date = DateTime.Now;

            _carImagesDal.Add(images);
            return new SuccessResult("Resim eklendi.");
        }

        public IResult Delete(CarImages images)
        {
            var result = _carImagesDal.Get(p => p.Id == images.Id);
            _fileHelper.DeleteFile(result.ImagePath);
            _carImagesDal.Delete(result);
            return new SuccessResult("Resim silindi");
        }

        public IDataResult<List<CarImages>> GetById(int id)
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(p => p.CarId == id));
        }

        public IResult Update(IFormFile file,CarImages images)
        {
            var result = _carImagesDal.Get(p => p.Id == images.Id);
            var image = _fileHelper.UpdateFile(file,PathConstant.Path, result.ImagePath);
            images.ImagePath = image;
            images.Date = DateTime.Now;
            _carImagesDal.Update(images);
            return new SuccessResult("Resim güncellendi.");
        }

        private IResult CheckCountOfCarImages(int id)
        {
            var result = _carImagesDal.GetAll(p => p.CarId == id).Count;

            if (result >= 5)
            {
                return new ErrorResult("Bir araca en fazla 5 tane resim eklenebilir");
            }

            return new SuccessResult();
        }

    }
}
