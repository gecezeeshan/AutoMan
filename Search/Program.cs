using Search.Interface;
using Search.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<ISearchService, SearchService>();// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddHttpClient("CourseService", c =>
{
    c.BaseAddress = new Uri(configuration["Services:Course"]);
});
builder.Services.AddHttpClient("LessonService", c =>
{
    c.BaseAddress = new Uri(configuration["Services:Lesson"]);
});

builder.Services.AddScoped<ICourseService,Courses.Services.CourseService>();
builder.Services.AddScoped<ILessonService, Lessons.Services.LessonService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
