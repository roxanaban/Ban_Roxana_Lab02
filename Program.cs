using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ban_Roxana_Lab2.Data;
using Microsoft.AspNetCore.Identity;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<Ban_Roxana_Lab2Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Ban_Roxana_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Ban_Roxana_Lab2Context' not found.")));
        builder.Services.AddDbContext<LibraryIdentityContext>(options =>

        options.UseSqlServer(builder.Configuration.GetConnectionString("Ban_Roxana_Lab2Context") ?? throw new InvalidOperationException("Connectionstring 'Ban_Roxana_Lab2Context' not found.")));
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<LibraryIdentityContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthentication(); ;

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}