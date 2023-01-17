using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Businness.Abstract
{
    public interface ICarImagesService
    {
        IResult Add(IFormFile file,CarImages images);
        IResult Delete(CarImages images);
        IResult Update(IFormFile file,CarImages images);
        IDataResult<List<CarImages>> GetById(int id);

    }
}
