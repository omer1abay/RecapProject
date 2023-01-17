using Businness.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController:ControllerBase
    {

        ITeamsService _teamsService;

        public TeamsController(ITeamsService teams)
        {
            _teamsService = teams;
        }

        [HttpGet("champion")]
        public IActionResult Get(string id)
        {
            var result = _teamsService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


    }
}
