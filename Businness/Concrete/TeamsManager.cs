using Businness.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.Concrete
{
    public class TeamsManager : ITeamsService
    {

        ITeamsDal _teamsDal;

        public TeamsManager(ITeamsDal teamsDal)
        {
            _teamsDal = teamsDal;
        }

        public IDataResult<Teams> GetById(string id)
        {
            return new SuccessDataResult<Teams>(_teamsDal.Get(p=> p.ID == id),"Şampiyon Galatasaray..");
        }
    }
}
