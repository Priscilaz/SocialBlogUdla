using BloggieWebProject.Data;
using BloggieWebProject.Repositorio;
using CloudinaryDotNet;
using FinalSolution.Data;
using FinalSolution.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BlogDbConnectionString")));

builder.Services.AddDbContext<AuthDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BlogAuthDbConnectionString")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

// Configuración del path de cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Cuenta/Login";
    options.AccessDeniedPath = "/Cuenta/AccessDenied";
});

builder.Services.AddScoped<IBlogPostRepositorio, BlogPostResositorio>();
builder.Services.AddScoped<IBlogPostCommentRepositorio, BlogPostCommentRepositorio>();
builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline. //LO PRIMERO QUE INICIA DE LA APLICACIÓN
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "customAccount",
    pattern: "Cuenta/{action=AccessDenied}/{id?}",
    defaults: new { controller = "Account", action = "AccessDenied" });

app.Run();
