using CPT231_Assignment06_LeviNoell_Baba;
using CPT231_Assignment06_LeviNoell_Baba.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache(); 
builder.Services.AddSession(options =>
    options.IdleTimeout = TimeSpan.FromSeconds(60 * 1)); //code used to determine how long sessions last

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NoellBabaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NoellBabaContext")));

builder.Services.AddRouting(options => //added code to add a trailing slash and lowercase urls
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

builder.Services.AddIdentity<User, IdentityRole>(options => //added parameters for passwords for user accounts
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}
).AddEntityFrameworkStores<NoellBabaContext>()
    .AddDefaultTokenProviders();

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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();



app.MapControllers();

app.MapAreaControllerRoute( //marpareacontrollerroute for the admin area
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );

app.MapAreaControllerRoute(//mapareacontrollerroute for the help area
    name: "help",
    areaName: "Help",
    pattern: "Help/{controller=Help}/{action=Index}/{id?}");



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

IServiceScopeFactory scopeFactory = app.Services.GetService<IServiceScopeFactory>(); //retrieve the Iservicescopefactory instance from the application's service container
using (IServiceScope scope = scopeFactory.CreateScope()) //create a new scope using the IserviceScopeFactory
{
    await CreateAdmin.CreateAdminAccountAsyn(scope.ServiceProvider); //asynchronously call a method to create an admin account
}

app.Run();
