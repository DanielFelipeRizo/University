using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.models.dataModels;
using System.Linq;
using System.Diagnostics;


namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        
        //acceso a las tablas del proyecto
        public ServicesController(UniversityDBContext context)
        {
            _context = context;
        }

        // GET: api/services/abc@mail.com
        [HttpGet("Email")]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            var userEmail = await _context.Users.FirstOrDefaultAsync(emailUser => emailUser.Email == email);

            if (userEmail == null)
            {
                return NotFound();
            }

            return userEmail;
        }

        // GET: api/services/EstudiantesMayores
        [HttpGet("EstudiantesMayores")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsGreater()
        {
            var estudiantesMayores = from studentsM in _context.students where studentsM.edad >= 18 select studentsM;
            return await estudiantesMayores.ToListAsync();

        }
        // GET: api/services/EstudiantesConCurso
        [HttpGet("EstudiantesConCurso")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsCourse()
        {
            //Buscar alumnos que tengan al menos un curso
            var StudentsCourse = _context.courses.SelectMany(course => course.Students);
            return await StudentsCourse.ToListAsync();

        }

    }
}
