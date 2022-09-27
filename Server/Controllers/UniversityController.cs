using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_App.Shared.StoredProcedures;

namespace University_App.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly UniversityContext _context;
        public UniversityController(UniversityContext context)
        {
            _context = context;
        }

        // GET ALL FACULTIES
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Faculty>>> Faculties()
        {
            List<Faculty> faculties = new List<Faculty>();
            faculties = await _context.Set<Faculty>()
                        .FromSqlRaw("dbo.spFaculty")
                        .ToListAsync();
            return await Task.FromResult(faculties);
        }

        // GET ALL STUDENTS AFTER CLICKING FACULTY
        [HttpGet("[action]/{Faculty_Id}")]
        public async Task<ActionResult<List<Student>>> Students(string Faculty_Id)
        {
            List<Student> students = new List<Student>();
            students = await _context.Set<Student>()
                        .FromSqlRaw("dbo.spStudents {0}", Faculty_Id)
                        .ToListAsync();
            return await Task.FromResult(students);
        }

        // GET COURSES TAKEN BY STUDENT
        [HttpGet("[action]/{Student_Id}")]
        public async Task<ActionResult<List<spStudent_Course>>> spStudent_Courses(string Student_Id)
        {
            List<spStudent_Course> student_courses = new List<spStudent_Course>();
            student_courses = await _context.Set<spStudent_Course>()
                                .FromSqlRaw("dbo.spStudent_Course {0}", Student_Id)
                                .ToListAsync();
            return await Task.FromResult(student_courses);
        }

    }
}
