﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _07._TeacherPupil.Models;

#nullable disable

namespace _07._TeacherPupil.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230318162845_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_07._TeacherPupil.Models.Pupil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClassNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pupils");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassNumber = "1A",
                            FirstName = "ჯეირან",
                            LastName = "დიღმელაშვილი"
                        },
                        new
                        {
                            Id = 2,
                            ClassNumber = "2B",
                            FirstName = "გიორგი",
                            LastName = "აბჟანდაძე"
                        },
                        new
                        {
                            Id = 3,
                            ClassNumber = "3C",
                            FirstName = "ბაკურ",
                            LastName = "სულაკაური"
                        },
                        new
                        {
                            Id = 4,
                            ClassNumber = "4D",
                            FirstName = "ანა",
                            LastName = "ირიმლიშვილი"
                        },
                        new
                        {
                            Id = 5,
                            ClassNumber = "5E",
                            FirstName = "ჯუმბერ",
                            LastName = "ტყაბლაძე"
                        });
                });

            modelBuilder.Entity("_07._TeacherPupil.Models.PupilSchoolSubject", b =>
                {
                    b.Property<int>("PupilId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("PupilId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("PupilSchoolSubjects");

                    b.HasData(
                        new
                        {
                            PupilId = 1,
                            SubjectId = 1
                        },
                        new
                        {
                            PupilId = 1,
                            SubjectId = 2
                        },
                        new
                        {
                            PupilId = 1,
                            SubjectId = 3
                        },
                        new
                        {
                            PupilId = 2,
                            SubjectId = 2
                        },
                        new
                        {
                            PupilId = 2,
                            SubjectId = 4
                        },
                        new
                        {
                            PupilId = 3,
                            SubjectId = 1
                        },
                        new
                        {
                            PupilId = 3,
                            SubjectId = 5
                        },
                        new
                        {
                            PupilId = 4,
                            SubjectId = 2
                        },
                        new
                        {
                            PupilId = 4,
                            SubjectId = 4
                        },
                        new
                        {
                            PupilId = 4,
                            SubjectId = 5
                        },
                        new
                        {
                            PupilId = 5,
                            SubjectId = 1
                        },
                        new
                        {
                            PupilId = 5,
                            SubjectId = 2
                        });
                });

            modelBuilder.Entity("_07._TeacherPupil.Models.SchoolSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SchoolSubjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "ქართული"
                        },
                        new
                        {
                            Id = 2,
                            Name = "მათემატიკა"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ისტორია"
                        },
                        new
                        {
                            Id = 4,
                            Name = "ინგლისური"
                        },
                        new
                        {
                            Id = 5,
                            Name = "გეოგრაფია"
                        });
                });

            modelBuilder.Entity("_07._TeacherPupil.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolSubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolSubjectId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "ბადრი",
                            Gender = "Male",
                            LastName = "ესებუა",
                            SchoolSubjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "მირიან",
                            Gender = "Female",
                            LastName = "მაღრაძე",
                            SchoolSubjectId = 2
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "თომას",
                            Gender = "Male",
                            LastName = "მანი",
                            SchoolSubjectId = 3
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "ალისა",
                            Gender = "Female",
                            LastName = "ჩიგოგიძე",
                            SchoolSubjectId = 4
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "ნუკრი",
                            Gender = "Male",
                            LastName = "ფრთხიალაშვილი",
                            SchoolSubjectId = 5
                        });
                });

            modelBuilder.Entity("_07._TeacherPupil.Models.PupilSchoolSubject", b =>
                {
                    b.HasOne("_07._TeacherPupil.Models.Pupil", "Pupil")
                        .WithMany("PupilSchoolSubjects")
                        .HasForeignKey("PupilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_07._TeacherPupil.Models.SchoolSubject", "SchoolSubject")
                        .WithMany("PupilSchoolSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pupil");

                    b.Navigation("SchoolSubject");
                });

            modelBuilder.Entity("_07._TeacherPupil.Models.Teacher", b =>
                {
                    b.HasOne("_07._TeacherPupil.Models.SchoolSubject", "SchoolSubject")
                        .WithMany("Teachers")
                        .HasForeignKey("SchoolSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SchoolSubject");
                });

            modelBuilder.Entity("_07._TeacherPupil.Models.Pupil", b =>
                {
                    b.Navigation("PupilSchoolSubjects");
                });

            modelBuilder.Entity("_07._TeacherPupil.Models.SchoolSubject", b =>
                {
                    b.Navigation("PupilSchoolSubjects");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
