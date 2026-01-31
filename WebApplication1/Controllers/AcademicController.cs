using Microsoft.AspNetCore.Mvc;      // gives ControllerBase, IActionResult, routing attributes
using Microsoft.EntityFrameworkCore; // gives async EF Core database methods

// tells ASP.NET this is an API controller (automatic model binding, validation etc.)
[ApiController]

// base URL will be: /api/Academic
// [controller] automatically becomes "Academic" (class name without "Controller")
[Route("api/[controller]")]
public class AcademicController : ControllerBase
{
    // private field to talk to database
    // readonly = cannot be reassigned after constructor (safer)
    private readonly ApplicationDbContext _context;

    // constructor = dependency injection
    // ASP.NET automatically provides ApplicationDbContext here
    // Interview answer:
    // "Constructor is used for dependency injection so the controller
    // gets database access without manually creating objects."
    public AcademicController(ApplicationDbContext context)
    {
        _context = context; // store db context for later use
    }

    // =========================
    // ====== CLASSES CRUD =====
    // =========================

    // GET /api/Academic/classes
    // returns all classes
    [HttpGet("classes")]
    public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
    {
        // ToListAsync() = execute SQL query and return list
        // async = non-blocking, better performance
        return await _context.Classes.ToListAsync();
    }

    // GET /api/Academic/classes/{id}
    // returns one class by primary key
    [HttpGet("classes/{id}")]
    public async Task<ActionResult<Class>> GetClass(string id)
    {
        // FindAsync searches by primary key
        var cls = await _context.Classes.FindAsync(id);

        // if nothing found → return 404
        if (cls == null)
            return NotFound();

        return cls; // 200 OK with data
    }

    // POST /api/Academic/classes
    // create new class
    [HttpPost("classes")]
    public async Task<ActionResult<Class>> CreateClass(Class cls)
    {
        // Add = mark entity as new
        _context.Classes.Add(cls);

        // SaveChangesAsync = actually write to database
        await _context.SaveChangesAsync();

        // CreatedAtAction = return 201 Created + location of new item
        // Interview answer:
        // "POST returns 201 Created to follow REST standards."
        return CreatedAtAction(nameof(GetClass),
            new { id = cls.ClassID }, cls);
    }

    // PUT /api/Academic/classes/{id}
    // update existing class
    [HttpPut("classes/{id}")]
    public async Task<IActionResult> UpdateClass(string id, Class cls)
    {
        // safety check: URL id must match body id
        if (id != cls.ClassID)
            return BadRequest();

        // mark entity as modified
        _context.Entry(cls).State = EntityState.Modified;

        // save changes to DB
        await _context.SaveChangesAsync();

        // NoContent = 204 success with no body
        // Interview answer:
        // "PUT returns 204 because update succeeds but no new resource is created."
        return NoContent();
    }

    // DELETE /api/Academic/classes/{id}
    // remove class
    [HttpDelete("classes/{id}")]
    public async Task<IActionResult> DeleteClass(string id)
    {
        // find class first
        var cls = await _context.Classes.FindAsync(id);

        if (cls == null)
            return NotFound();

        // remove from DB context
        _context.Classes.Remove(cls);

        // commit deletion
        await _context.SaveChangesAsync();

        return NoContent(); // 204 success
    }

    // =========================
    // ===== COURSES CRUD ======
    // =========================

    // GET all courses
    [HttpGet("courses")]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    // GET one course by code (primary key)
    [HttpGet("courses/{code}")]
    public async Task<ActionResult<Course>> GetCourse(string code)
    {
        var course = await _context.Courses.FindAsync(code);

        if (course == null)
            return NotFound();

        return course;
    }

    // POST create new course
    [HttpPost("courses")]
    public async Task<ActionResult<Course>> CreateCourse(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCourse),
            new { code = course.CourseCode }, course);
    }

    // PUT update course
    [HttpPut("courses/{code}")]
    public async Task<IActionResult> UpdateCourse(string code, Course course)
    {
        if (code != course.CourseCode)
            return BadRequest();

        _context.Entry(course).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE remove course
    [HttpDelete("courses/{code}")]
    public async Task<IActionResult> DeleteCourse(string code)
    {
        var course = await _context.Courses.FindAsync(code);

        if (course == null)
            return NotFound();

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
