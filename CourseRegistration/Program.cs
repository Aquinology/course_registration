using Microsoft.EntityFrameworkCore;
using CourseRegistration.Data;
using CourseRegistration.Interfaces;
using CourseRegistration.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CourseRegistrationContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("CourseRegistrationContext") ?? throw new InvalidOperationException("Connection string 'CourseRegistrationContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ICourseRepository, CourseRepository>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IRegistrationSheetRepository, RegistrationSheetRepository>();
builder.Services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
