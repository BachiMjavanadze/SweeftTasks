namespace _07._TeacherPupil.Models;
public class SchoolSubject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<PupilSchoolSubject> PupilSchoolSubjects { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
}
