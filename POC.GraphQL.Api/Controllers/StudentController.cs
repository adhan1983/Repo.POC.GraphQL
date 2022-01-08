using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using POC.GraphQL.Service.Dtos;
using POC.GraphQL.Service.Interfaces.Services;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace POC.GraphQL.Api.Controllers
{
    [Route("api/v1/students")]
    [OpenApiTag("Exchanges", Description = "All Students in database")]
    [ApiController]
    public class StudentController : Controller
    {
        
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService) => this._studentService = studentService;

        
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, typeof(List<StudentDto>), Description = "The Students")]
        public async Task<IActionResult> GetAllAsync()
        {
            var studendsDto = await _studentService.GetStudentAllAsync();
            
            return Ok(studendsDto);
        }

        [HttpGet("id")]
        [SwaggerResponse(HttpStatusCode.OK, typeof(StudentDto), Description = "The Student")]
        public async Task<IActionResult> Get(int id)
        {
            var studendDto = await _studentService.GetStudentByIdAsync(id);

            return Ok(studendDto);
        }



    }
}
