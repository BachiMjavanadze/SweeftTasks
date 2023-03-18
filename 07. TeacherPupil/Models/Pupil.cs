namespace _07._TeacherPupil.Models;
public class Pupil
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ClassNumber { get; set; }
    public ICollection<PupilSchoolSubject> PupilSchoolSubjects { get; set; }
}