//using LibraryManagementSystemWebApplication.Areas.Identity;
using Microsoft.EntityFrameworkCore;
//using LibraryManagementSystemWebApplication.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using LibraryManagementSystemWebApplication.Data;
using LibraryManagementSystemWebApplication.GenericRepository;
using LibraryManagementSystemWebApplication.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryPortal")));

builder.Services.AddScoped(typeof(IGenericRepositoryLMS<Admin>), typeof(GenericRepositoryLMS<Admin>));
builder.Services.AddScoped(typeof(IGenericRepositoryLMS<Books>), typeof(GenericRepositoryLMS<Books>));


//builder.Services.AddDefaultIdentity<SampleUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LibraryIdentityContext>();


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

//app.MapRazorPages();
app.Run();
