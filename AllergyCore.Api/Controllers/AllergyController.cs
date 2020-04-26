using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllergyCore.Business.Services.Abstarct;
using AllergyCore.Entity.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllergyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private IAllergyService _allergyService;
        public AllergyController(IAllergyService allergyService)
        {
            _allergyService = allergyService;

        }
        [HttpPost("Add")]
        public IActionResult Add(Allergies allergy)
        {
            var result = _allergyService.Add(allergy);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(int id, Allergies allergy)
        {
            var result = _allergyService.Update(id, allergy);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("Remove")]
        public IActionResult Remove(int id)
        {
            var result = _allergyService.Remove(id);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _allergyService.Get(id);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll(int id)
        {
            var result = _allergyService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

    }
}