
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
builder.Services.AddScoped<IDriverComCatRepo, DriverComCatRepo>();////////NEW
builder.Services.AddScoped<IDriverCompanyRepo, DriverCompanyRepo>();
builder.Services.AddScoped<IDriverCompContractRepo, DriverCompContractRepo>();////////NEW
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
    pattern: "{controller=ContractCompany}/{action=Index}/{id?}");

app.Run();
