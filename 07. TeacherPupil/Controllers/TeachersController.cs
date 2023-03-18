using _07._TeacherPupil.Models;
using Microsoft.AspNetCore.Mvc;

namespace _07._TeacherPupil.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TeachersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("GiorgisTeachers")]
    public async Task<ActionResult<Teacher>> GetGiorgisTeachers()
    {

        var giorgisTeachers = GetPupil("გიორგი");
        return Ok(giorgisTeachers);
    }

    [HttpGet("{firstName}")]
    public async Task<ActionResult<Teacher>> GetPupilTeachersByFirstName(string firstName)
    {
        List<Teacher> pupilTeacher = GetPupil(firstName);
        return Ok(pupilTeacher);
    }

    private List<Teacher> GetPupil(string firstName)
    {
        return _context.Teachers
        .Join(_context.SchoolSubjects,
            teacher => teacher.SchoolSubjectId,
            subject => subject.Id,
            (teacher, subject) => new { Teacher = teacher, Subject = subject })
        .Join(_context.PupilSchoolSubjects,
            ts => ts.Subject.Id,
            pss => pss.SubjectId,
            (ts, pss) => new { ts.Teacher, pss.PupilId })
        .Join(_context.Pupils,
            tsid => tsid.PupilId,
            pupil => pupil.Id,
            (tsid, pupil) => new { tsid.Teacher, Pupil = pupil })
        .Where(tp => tp.Pupil.FirstName == firstName)
        .Select(tp => tp.Teacher)
        .Distinct()
        .ToList();
    }
}
