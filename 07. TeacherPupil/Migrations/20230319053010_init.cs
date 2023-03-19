using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _07._TeacherPupil.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pupils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pupils", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PupilSchoolSubjects",
                columns: table => new
                {
                    PupilId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PupilSchoolSubjects", x => new { x.PupilId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_PupilSchoolSubjects_Pupils_PupilId",
                        column: x => x.PupilId,
                        principalTable: "Pupils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PupilSchoolSubjects_SchoolSubjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "SchoolSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_SchoolSubjects_SchoolSubjectId",
                        column: x => x.SchoolSubjectId,
                        principalTable: "SchoolSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pupils",
                columns: new[] { "Id", "ClassNumber", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "1A", "ჯეირან", "დიღმელაშვილი" },
                    { 2, "2B", "გიორგი", "აბჟანდაძე" },
                    { 3, "3C", "ბაკურ", "სულაკაური" },
                    { 4, "4D", "ანა", "ირიმლიშვილი" },
                    { 5, "5E", "ჯუმბერ", "ტყაბლაძე" }
                });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ქართული" },
                    { 2, "მათემატიკა" },
                    { 3, "ისტორია" },
                    { 4, "ინგლისური" },
                    { 5, "გეოგრაფია" }
                });

            migrationBuilder.InsertData(
                table: "PupilSchoolSubjects",
                columns: new[] { "PupilId", "SubjectId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 5 },
                    { 4, 2 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 1 },
                    { 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "SchoolSubjectId" },
                values: new object[,]
                {
                    { 1, "ბადრი", "Male", "ესებუა", 1 },
                    { 2, "მირიან", "Female", "მაღრაძე", 2 },
                    { 3, "თომას", "Male", "მანი", 3 },
                    { 4, "ალისა", "Female", "ჩიგოგიძე", 4 },
                    { 5, "ნუკრი", "Male", "ფრთხიალაშვილი", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PupilSchoolSubjects_SubjectId",
                table: "PupilSchoolSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SchoolSubjectId",
                table: "Teachers",
                column: "SchoolSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PupilSchoolSubjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Pupils");

            migrationBuilder.DropTable(
                name: "SchoolSubjects");
        }
    }
}
