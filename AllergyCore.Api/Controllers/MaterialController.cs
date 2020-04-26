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
    public class MaterialController : BaseController<Materials, IMaterialService>
    {
        public MaterialController(IMaterialService service) : base(service)
        {

        }
        //private IMaterialService _materialService;
        //public MaterialController(IMaterialService materialService)
        //{
        //    _materialService = materialService;
        //}

        //[HttpPost("Add")]
        //public IActionResult Add(Materials Material)
        //{
        //    var result = _materialService.Add(Material);
        //    if (!result.IsSuccess)
        //        return BadRequest(result);
        //    return Ok(result);

        //}
        //[HttpDelete("Remove")]
        //public IActionResult Remove(int id)
        //{
        //    var result = _materialService.Remove(id);
        //    if (!result.IsSuccess)
        //        return BadRequest(result);
        //    return Ok(result);
        //}
        //[HttpPut("Update")]
        //public IActionResult Update(int id, Materials Material)
        //{
        //    var result = _materialService.Update(Material.Id, Material);
        //    if (!result.IsSuccess)
        //        return BadRequest(result);
        //    return Ok(result);
        //}
        //[HttpGet("Get")]
        //public IActionResult Get(int id)
        //{
        //    var result = _materialService.Get(id);
        //    if (!result.IsSuccess)
        //        return BadRequest(result);
        //    return Ok(result);
        //}
        //[HttpGet("GetAll")]
        //public IActionResult GetAll()
        //{
        //    var result = _materialService.GetAll();
        //    if (!result.IsSuccess)
        //        return BadRequest(result);
        //    return Ok(result);
        //}
    }
}