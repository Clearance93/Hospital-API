using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyApplication.Models;
using ParkyApplication.Models.Dtos;
using ParkyApplication.Repository.IRepository;

namespace ParkyApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository _rep;
        private readonly IMapper _map;

        public NationalParkController(INationalParkRepository rep, IMapper map)
        {
            _rep = rep;
            _map = map;
        }

        ///<Summary>
        ///Get list of all national park
        ///</Summary>
        ///<returns></returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<NationalParkDtos>))]
        public IActionResult GetNationalPark()
        {
            var objList = _rep.GetNationalParks();
            var objDto = new List<NationalParkDtos>();

            foreach (var obj in objList)
            {
                objDto.Add(_map.Map<NationalParkDtos>(obj));
            }


            return Ok(objDto);
        }

        [HttpGet("{parkId:int}", Name = "GetNationalPark")]
        [ProducesResponseType(200, Type = typeof(NationalParkDtos))]
        [ProducesResponseType(404)]
        public IActionResult GetNationalPark(int parkId)
        {
            var obj = _rep.GetNationalPark(parkId);
            if (obj == null)
            {
                return NotFound();
            }

            var objDto = _map.Map<NationalParkDtos>(obj);

            ///
            ///var objDto = new NationalParkDtos(){
            /// Created = obj.created,
            /// Id = obj.Id,
            /// Name = obj.Name,
            /// State = obj.State
            /// };
            return Ok(objDto);
        }

        ///<Summary>
        /// Get individual national park
        ///</Summary>
        /// <param name="nationalParkId">The Id of the national park</param>
        ///<returns></returns>

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(NationalParkDtos))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateNationalPark([FromBody] NationalParkDtos parkDto)
        {
            if (parkDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_rep.NationalParkExists(parkDto.Name))
            {
                ModelState.AddModelError("", "National Park Exists");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var parkObj = _map.Map<NationalParkModel>(parkDto);

            if (!_rep.CreateNationalPark(parkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {parkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetNationalPark", new { parkId = parkObj.nationslParkId }, parkObj);
        }

        [HttpPatch("{parkId:int}", Name = "GetNationalPark")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdatenationalPark(int parkId, [FromBody] NationalParkDtos parkDto)
        {
            if (parkDto == null || parkId != parkDto.nationslParkId)
            {
                return BadRequest(ModelState);
            }

            var parkObj = _map.Map<NationalParkModel>(parkDto);
            if (!_rep.UpdateNationalPark(parkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when Updating the record {parkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{parkId:int}", Name = "DeleteNationalPark")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteNationalPark(int parkId)
        {
            if (!_rep.NationalParkExists(parkId))
            {
                return NotFound();
            }

            var parkObj = _rep.GetNationalPark(parkId);
            if (!_rep.DeleteNationalPark(parkObj))
            {
                ModelState.AddModelError("", $"Something went wrong when trying to delete the record {parkObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}