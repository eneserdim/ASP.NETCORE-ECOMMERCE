using EEducation.Core.Service;
using EEducation.Model.Context;
using EEducation.Service.DbService;
using Microsoft.EntityFrameworkCore;

namespace EEducation.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMvc();

            builder.Services.AddDbContext<EEducationContext>(options => options.UseSqlServer("Server=DESKTOP-JG5V82N\\SQLEXPRESS;Database=EEducation;TrustServerCertificate=True;Integrated Security=true;"));

            // Dependency Injection(Baðýmlýlýklarýn Enjekte Edilmesi) ile IDbService türünde bir nesne örneði oluþturmak istediðimizde geriye bize CoreDbService sýnýfýna ait bir nesne örneði döner ve sorgularýmýzý aslýnda bu sýnýf üzerinden yazabilir hale geliriz.
            builder.Services.AddScoped(typeof(IDbService<>), typeof(CoreDbService<>));

            builder.Services.AddSession(); // Session oturum yönetimi servis olarak ekle

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

            app.UseSession(); // Session oturum yöntemini kullan dedik

            app.UseRouting();

            app.UseAuthorization();

            // Area tarafý için bir routing yazýmý yaptýk
            app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{Controller=Home}/{Action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{Controller=Home}/{Action=Index}/{id?}"
            );

            app.Run();
        }
    }
}