using CRM.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.EntityFrameworkCore;
using CRM.Data.Interfaces;
using CRM.Data;
using CRM.API.Implementations;
using CRM.API.Interfaces;
using CRM.DAL;
using static Azure.Core.HttpHeader;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy();

app.Map("/admin", [Authorize(Roles = "Admin")] () => "Admin Panel");

app.MapGet("/logout", async (HttpContext context) =>
{
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return "Äàííûå óäàëåíû";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Worker}/{action=Index}/{id?}");

app.Run();
