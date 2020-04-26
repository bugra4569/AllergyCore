using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllergyCore.Business.Constants;
using AllergyCore.Business.Services.Abstarct;
using AllergyCore.Core.Dto.Concrete;
using AllergyCore.Entity.EntityFramework.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllergyCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IIngredientService _ingredientService;
        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost("Add")]

        public IActionResult Add(Ingredients ingredient)
        {
            var result = _ingredientService.Add(ingredient);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);

        }
        [HttpDelete("Remove")]
        public IActionResult Remove(int id)
        {
            var result = _ingredientService.Remove(id);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(int id, Ingredients ingredient)
        {
            var result = _ingredientService.Update(ingredient.Id, ingredient);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _ingredientService.Get(id);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _ingredientService.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
    }
}