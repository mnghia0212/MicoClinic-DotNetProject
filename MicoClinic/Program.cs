using MicoClinic.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
//builder.Services.AddScoped<SessionAppointment>();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ClinicDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

builder.Services.AddScoped<IClinicRepository, EFClinicRepository>();
builder.Services.AddScoped<IAppointmentRepository, EFAppointmentRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("deppage",
    "{department}/Page{doctorPage:int}", new { Controller = "Home", action = "Doctor" });

app.MapControllerRoute("page",
    "Page{doctorPage:int}", new { Controller = "Home", action = "Doctor", doctorPage = 1 });

app.MapControllerRoute("department",
    "{department}", new { Controller = "Home", action = "Doctor", doctorPage = 1 });

app.MapControllerRoute("pagination",
    "Doctors/Page{doctorPage}", new { Controller = "Home", action = "Doctor", doctorPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

SeedData.EnsurePopulated(app);

app.Run();
