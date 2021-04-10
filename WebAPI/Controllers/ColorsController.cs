using Business.Abstack;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
         IColorService _colorservice;
        public ColorsController(IColorService colorService)
        {
            _colorservice = colorService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _colorservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
     
        [HttpGet("getbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _colorservice.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorservice.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorservice.Delete(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorservice.Update(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
