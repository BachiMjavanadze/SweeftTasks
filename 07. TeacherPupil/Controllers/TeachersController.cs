﻿using _07._TeacherPupil.DTO;
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
    public ActionResult<IEnumerable<TeacherDto>> GetGiorgisTeachers()
    {
        return Ok(FilterTeachers("გიორგი"));
    }

    [HttpGet("{firstName}")]
    public ActionResult<IEnumerable<TeacherDto>> GetPupilTeachers(string firstName)
    {
        return Ok(FilterTeachers(firstName));
    }

    private ActionResult<IEnumerable<TeacherDto>> FilterTeachers(string firstName)
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
        .Select(tp => new TeacherDto
        {
            Id = tp.Teacher.Id,
            FirstName = tp.Teacher.FirstName,
            LastName = tp.Teacher.LastName,
            SchoolSubject = tp.Teacher.SchoolSubject.Name
        })
        .Distinct()
        .ToList();
    }
}


