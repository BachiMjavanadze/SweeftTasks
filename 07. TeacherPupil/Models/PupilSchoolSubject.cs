namespace _07._TeacherPupil.Models;
public class PupilSchoolSubject
{
    public int PupilId { get; set; }
    public Pupil Pupil { get; set; }
    public int SubjectId { get; set; }
    public SchoolSubject SchoolSubject { get; set; }
}
