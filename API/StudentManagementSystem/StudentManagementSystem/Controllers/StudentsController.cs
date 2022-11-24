using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly StudentDbContext studentDbContext;
        public StudentsController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudetns()
        {
            var students = await studentDbContext.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetStudent")]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var student = await studentDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound("Student not found");
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            student.StudentId = Guid.NewGuid();
            await studentDbContext.Students.AddAsync(student);
            await studentDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, student);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCard([FromRoute] Guid id, [FromBody] Student student)
        {
            var existingStudent = await studentDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (existingStudent != null)
            {
                existingStudent.StudentName = student.StudentName;
                existingStudent.Department = student.Department;
                existingStudent.Email = student.Email;
                existingStudent.CGPA = student.CGPA;
                await studentDbContext.SaveChangesAsync();
                return Ok(existingStudent);
            }
            return NotFound("Student not found");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var existingStudent = await studentDbContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            if (existingStudent != null)
            {
                studentDbContext.Remove(existingStudent);
                await studentDbContext.SaveChangesAsync();
                return Ok(existingStudent);
            }
            return NotFound("Student not found");
        }

    }
}
