using MCC75NET.Contexts;
using MCC75NET.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext to Sql Server Database
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));

// Dependency Injection
builder.Services.AddScoped<UniversityRepository>();
builder.Services.AddScoped<EducationRepository>();
builder.Services.AddScoped<AccountRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<RoleRepository>();

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
