using _07._TeacherPupil.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/* Database Migrations CLI Commands
 *
 * Add the "--verbose" flag to the end of the command if you want to get detailed information in the console.
 * 

 Migration:

      dotnet ef migrations add "init" --project "D:\SwiftTasks\07. TeacherPupil\07. TeacherPupil.csproj" --startup-project "D:\SwiftTasks\07. TeacherPupil\07. TeacherPupil.csproj" --context ApplicationDbContext

Update:

      dotnet ef database update --project "D:\SwiftTasks\07. TeacherPupil\07. TeacherPupil.csproj" --startup-project "D:\SwiftTasks\07. TeacherPupil\07. TeacherPupil.csproj" --context ApplicationDbContext

Remove last migration:

      dotnet ef migrations remove --project "FULL_PATH_OF_THE_PROJECT_WHERE_IS_MIGRATIONS_FOLDER" -f
*/
