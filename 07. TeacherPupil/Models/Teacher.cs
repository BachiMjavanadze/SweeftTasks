namespace _07._TeacherPupil.Models;
public class Teacher
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int SchoolSubjectId { get; set; }
    public SchoolSubject SchoolSubject { get; set; }
}
