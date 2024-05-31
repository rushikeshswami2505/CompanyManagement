using CompanyManagement.Data;
using CompanyManagement.Services;
using CompanyManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache(); // This adds a default in-memory implementation of IDistributedCache
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(120); 
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<Context>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));
builder.Services.AddTransient<IEmployeeDetails, EmployeeDetailsServices>();
builder.Services.AddTransient<IProjectDetails, ProjectDetailsServices>();
builder.Services.AddTransient<ILeaveDetails, LeaveDetailsServices>();
builder.Services.AddTransient<IEmployeeLeave, EmployeeLeaveServices>();
builder.Services.AddTransient<IRoleDetails, RoleDetailsServices>();

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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
