using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Abstract
{
    public interface ITeamsService
    {
        IDataResult<Teams> GetById(string id);
    }
}
