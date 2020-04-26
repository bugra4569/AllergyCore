using AllergyCore.Business.Services.Abstarct;
using AllergyCore.Core.Entity;
using AllergyCore.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllergyCore.Api.Controllers
{
    public abstract class BaseController<T, TService> : ControllerBase
        where T : class, IEntity, new()
        where TService : IService<T>
    {
        private TService _service;
        public BaseController(TService service)
        {
            _service = service;
        }

        [HttpPost("Add")]

        public IActionResult Add(T entity)
        {
            var result = _service.Add(entity);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);

        }
        [HttpDelete("Remove")]
        public IActionResult Remove(int id)
        {
            var result = _service.Remove(id);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("Update")]
        public IActionResult Update(int id, T entity)
        {
            var result = _service.Update(id, entity);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
