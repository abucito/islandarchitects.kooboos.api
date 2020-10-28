using System;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.API.Base;
using Recipe.API.Entities;
using Recipe.API.Models;

namespace Recipe.API.Units
{
    [ApiController]
    [Route("api/units")]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitsService unitsService;

        private readonly IMapper mapper;

        public UnitsController(IUnitsService unitsService, IMapper mapper)
        {
            this.unitsService = unitsService ?? throw new ArgumentNullException(nameof(unitsService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetUnits()
        {
            var units = unitsService.GetAll();

            return Ok(units);
        }

        [HttpGet("{id}", Name = "GetUnit")]
        public IActionResult GetUnit(int id)
        {
            var unit = unitsService.GetById(id);

            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        [HttpPost]
        public IActionResult CreateUnit(UnitForCreationDto unitForCreation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unitDto = mapper.Map<UnitDto>(unitForCreation);

            var idOfNewUnit = unitsService.Insert(unitDto);

            if (idOfNewUnit > 0)
            {
                unitDto.Id = idOfNewUnit;
                return CreatedAtRoute("GetUnit", new { Id = idOfNewUnit }, unitDto);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUnit(int id)
        {
            var unitToDelete = unitsService.GetById(id);

            if (unitToDelete == null)
            {
                return NotFound();
            }

            unitsService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult FullyUpdateUnit(int id, UnitForUpdateDto unitForUpdateDto)
        {
            var unitToUpdate = unitsService.GetById(id);

            if (unitToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unitDtoWithNewValues = mapper.Map<UnitDto>(unitForUpdateDto);

            unitsService.FullyUpdate(id, unitDtoWithNewValues);

            return NoContent();
        }
    }
}