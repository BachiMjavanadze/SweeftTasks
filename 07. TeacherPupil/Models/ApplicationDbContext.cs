using Microsoft.EntityFrameworkCore;

namespace _07._TeacherPupil.Models;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<SchoolSubject> SchoolSubjects { get; set; }
    public DbSet<Pupil> Pupils { get; set; }
    public DbSet<PupilSchoolSubject> PupilSchoolSubjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PupilSchoolSubject>()
            .HasKey(pss => new { pss.PupilId, pss.SubjectId });

        modelBuilder.Entity<PupilSchoolSubject>()
            .HasOne(pss => pss.Pupil)
            .WithMany(p => p.PupilSchoolSubjects)
            .HasForeignKey(pss => pss.PupilId);

        modelBuilder.Entity<PupilSchoolSubject>()
            .HasOne(pss => pss.SchoolSubject)
            .WithMany(s => s.PupilSchoolSubjects)
            .HasForeignKey(pss => pss.SubjectId);

        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.SchoolSubject)
            .WithMany(s => s.Teachers)
            .HasForeignKey(t => t.SchoolSubjectId);

        modelBuilder.Entity<SchoolSubject>().HasData(
            new SchoolSubject { Id = 1, Name = "ქართული" },
            new SchoolSubject { Id = 2, Name = "მათემატიკა" },
            new SchoolSubject { Id = 3, Name = "ისტორია" },
            new SchoolSubject { Id = 4, Name = "ინგლისური" },
            new SchoolSubject { Id = 5, Name = "გეოგრაფია" });

        modelBuilder.Entity<Pupil>().HasData(
            new Pupil { Id = 1, FirstName = "ჯეირან", LastName = "დიღმელაშვილი", ClassNumber = "1A" },
            new Pupil { Id = 2, FirstName = "გიორგი", LastName = "აბჟანდაძე", ClassNumber = "2B" },
            new Pupil { Id = 3, FirstName = "ბაკურ", LastName = "სულაკაური", ClassNumber = "3C" },
            new Pupil { Id = 4, FirstName = "ანა", LastName = "ირიმლიშვილი", ClassNumber = "4D" },
            new Pupil { Id = 5, FirstName = "ჯუმბერ", LastName = "ტყაბლაძე", ClassNumber = "5E" });

        modelBuilder.Entity<Teacher>().HasData(
            new Teacher { Id = 1, FirstName = "ბადრი", LastName = "ესებუა", Gender = "Male", SchoolSubjectId = 1 },
            new Teacher { Id = 2, FirstName = "მირიან", LastName = "მაღრაძე", Gender = "Female", SchoolSubjectId = 2 },
            new Teacher { Id = 3, FirstName = "თომას", LastName = "მანი", Gender = "Male", SchoolSubjectId = 3 },
            new Teacher { Id = 4, FirstName = "ალისა", LastName = "ჩიგოგიძე", Gender = "Female", SchoolSubjectId = 4 },
            new Teacher { Id = 5, FirstName = "ნუკრი", LastName = "ფრთხიალაშვილი", Gender = "Male", SchoolSubjectId = 5 });

        modelBuilder.Entity<PupilSchoolSubject>().HasData(
            new PupilSchoolSubject { PupilId = 1, SubjectId = 1 },
            new PupilSchoolSubject { PupilId = 1, SubjectId = 2 },
            new PupilSchoolSubject { PupilId = 1, SubjectId = 3 },
            new PupilSchoolSubject { PupilId = 2, SubjectId = 2 },
            new PupilSchoolSubject { PupilId = 2, SubjectId = 4 },
            new PupilSchoolSubject { PupilId = 3, SubjectId = 1 },
            new PupilSchoolSubject { PupilId = 3, SubjectId = 5 },
            new PupilSchoolSubject { PupilId = 4, SubjectId = 2 },
            new PupilSchoolSubject { PupilId = 4, SubjectId = 4 },
            new PupilSchoolSubject { PupilId = 4, SubjectId = 5 },
            new PupilSchoolSubject { PupilId = 5, SubjectId = 1 },
            new PupilSchoolSubject { PupilId = 5, SubjectId = 2 });
    }
}
