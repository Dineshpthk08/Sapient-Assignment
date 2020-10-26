using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicineTracker.Models;
using MedicineTracker.Services.Interfaces;
using MedicineTracker.Validation;

namespace MedicineTracker.Controllers
{
    [Route("blogs")]
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this._medicineService = medicineService;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Medicine medicine)
        {
            if (medicine.IsValid(out IEnumerable<string> errors))
            {
                var result = await _medicineService.Create(medicine);

                return CreatedAtAction(
                    nameof(Create),
                    new { id = result.Id }, result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] Medicine medicine)
        {
            if (medicine.IsValid(out IEnumerable<string> errors))
            {
                var result = await _medicineService.Update(medicine);

                return Ok(result);
            }
            else
            {
                return BadRequest(errors);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var result = _medicineService.GetAll();

            return Ok(result);
        }

        [HttpPost("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var result = await _medicineService.Delete(id);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

