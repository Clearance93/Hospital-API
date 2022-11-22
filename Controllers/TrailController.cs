using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyApplication.Models;
using ParkyApplication.Models.Dtos;
using ParkyApplication.Repository.IRepository;

namespace ParkyApplication.Controllers
{
    [Route("api/Trails")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class TrailController : Controller
    {
        private readonly ITrailsRepository _rep;
        private readonly IMapper _map;

        public TrailController(ITrailsRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetTrails()
        {
            var objList = _rep.GetTrails();
            var objDto = new List<TrailDto>();

            foreach(var obj in objList)
            {
                objDto.Add(_map.Map<TrailDto>(obj));
            }
            return Ok(objDto);
        }

        [HttpGet("{trailId:int}", Name = "GetTrail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetTrail(int id)
        {
            var obj = _rep.GetTrail(id);
            if(obj == null)
            {
                return NotFound();
            }

            var objDto = _map.Map<TrailDto>(obj);
            return Ok(objDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created, Type =typeof(TrailDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateTrail([FromBody] CreateTrailDto trailDto)
        {
            if(trailDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_rep.TrailExist(trailDto.Name))
            {
                ModelState.AddModelError("", "The trail with this name does exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objtrail = _map.Map<TrailModels>(trailDto);
            if (!_rep.CreateTrail(objtrail))
            {
                ModelState.AddModelError("", $"Something went wrong while trying to add the trail {objtrail.Name}. Please try again");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetTrail", new { trailId = objtrail.trailId }, objtrail);
        }
    }
}
