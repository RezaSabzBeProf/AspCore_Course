using AspCore_Course.Models;
using AspCore_Course.Service;
using AspCore_Course.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Rewrite;
using WebMarkupMin.AspNetCore6;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddWebMarkupMin()
    .AddHtmlMinification()
    .AddHttpCompression()
    .AddXmlMinification();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region Identity
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options=>
{
    options.LoginPath = "/Home/Login";
    options.LogoutPath = "/Home/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
});
#endregion



builder.Services.AddDbContext<FarsLearnContext>(p =>
{
    p.UseSqlServer(builder.Configuration.GetConnectionString("Defualt"));
}
            );

builder.Services.AddTransient<IPostService, PostService>();

var app = builder.Build();

app.UseRewriter(new RewriteOptions()
    .AddRedirectToWww()
    .AddRedirectToHttps()
    );

app.Use(async (context, next) =>
{
    await next();
    if(context.Response.StatusCode == 404)
    {
        context.Response.Redirect("/Home/Error404");
    }
});

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
app.UseWebMarkupMin();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
