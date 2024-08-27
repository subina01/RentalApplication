using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RentalProject.Repositories.Implementation;
using RentalProject.Repositories.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
//configure dbContext with ConnectionString
builder.Services.AddDbContext<RentalProject.Repositories.CarContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddAutoMapper(typeof(VehicleRepository));
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
app.UseMiddleware<ExceptionHandlerMiddleware>();


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicles}/{action=Index}/{id?}");

app.Run();
