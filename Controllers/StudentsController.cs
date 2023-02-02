using ArishProject.Dtos;
using ArishProject.Entities;
using ArishProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArishProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepostiory repository;
        public StudentsController(IStudentsRepostiory repository)
        {
            this.repository = repository;

        }

        [HttpGet]
        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            return (await repository.GetStudentsAsync()).Select(student=>student.AsDto());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentAsync(string id)
        {
            var student = await repository.GetStudentAsync(id);
            if(student is null)
            {
                return NotFound();
            }
            return student.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(CreateStudentDto studentDto)
        {
            Student student = new()
            {
               
                Id = studentDto.Id,
                NameAr = studentDto.NameAr,
                NameEn = studentDto.NameEn,
                Department = studentDto.Department,
                Grade = studentDto.Grade
            };
            await repository.CreateStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentAsync), new { id = student.Id }, student.AsDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudentAsync(string id , UpdateStudentDto studentDto)
        {
            var existingStudent = await repository.GetStudentAsync(id);
            if(existingStudent is null)
            {
                return NotFound();
            }
            Student updatedStudent = existingStudent with
            {
                NameAr = studentDto.NameAr,
                NameEn = studentDto.NameEn,
                Id = studentDto.Id,
                Department = studentDto.Department,
                Grade = studentDto.Grade
            };
            await repository.UpdateStudentAsync(updatedStudent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentAsync(string id)
        {
            var existingStudent = await repository.GetStudentAsync(id);
            if (existingStudent is null)
            {
                return NotFound();
            }


            await repository.DeleteStudentAsync(id);
            return NoContent();
        }

    }
}
