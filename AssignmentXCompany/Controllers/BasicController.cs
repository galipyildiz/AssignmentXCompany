﻿using AssignmentXCompany.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentXCompany.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Get()
        {
            //Task 1.1
            return Ok("Hello World!");
        }

        [HttpGet]
        public IActionResult AvarageofInputs([FromQuery] int[] numbers)
        {
            try
            {
                //Task 1.2
                var result = BasicService.Avarage(numbers);
                return Ok($"Result: {result:N2}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
