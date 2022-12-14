
using Labbeh.Data;
using Labbeh.IRepository;
using Labbeh.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
//using static NPOI.XSSF.UserModel.Charts.XSSFLineChartData<Tx, Ty>;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDriverComCatRepo, DriverComCatRepo>();
builder.Services.AddScoped<IDriverCompanyRepo, DriverCompanyRepo>();
builder.Services.AddScoped<IDriverCompContractRepo, DriverCompContractRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<IVehiclesRepo, VehiclesRepo>();
builder.Services.AddScoped<IDriverVehicleseRepo, DriverVehicleRepo>();
builder.Services.AddScoped<ICustomerCategoryRepo, CustomerCategoryRepo>();
builder.Services.AddDbContext<DBContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("LabbehConnection")));

//builder.Services.AddDbContext<DBContext>(option => option.UseSqlServer(builder.Configuration.GetSection("ConnectionString:dbconn").Value));
//builder.Services.AddDefaultIdentity<>(Options => SignIn.RequireConfirmesAccount = false)
  //  .AddEntityFrameworkStores<DBContext>();

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
    pattern: "{controller=Company}/{action=Index}/{id?}");

app.Run();
