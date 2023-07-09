using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AgroCare1.Data;
using Models;
using AgroCare1.Services.Interface;
using AgroCare1.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IServicesRepository<>),typeof(ServicesRepository<>));
builder.Services.AddScoped<IServicesRepository<Buyer> , BuyerRepository>();
builder.Services.AddScoped<IServicesRepository<Store> , StroeRepository>();
builder.Services.AddScoped<IServicesRepository<Farmer> , FarmerRepository>();
builder.Services.AddScoped<IServicesRepository<Engineer> , EngineerRepository>();
builder.Services.AddScoped<IServicesRepository<Step> , StepsRepository>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<AppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("constr")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
