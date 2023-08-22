using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using System.IO;
using ConsoleToweb.Data;
using Microsoft.EntityFrameworkCore;
using ConsoleToweb.Repository;

namespace ConsoleToWeb
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //add data context here
            services.AddDbContext<BookStoreContext>(
                options => options.UseSqlServer("Server=;Database=bookstore;Integrated Security=True"));


            //Razor view engine --REFLECT DYANAMIC CHANGE (microsoft.aspnetcore.MVC.RAzor.runtime.compilation---package adding)
        #if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();

        #endif

            services.AddScoped<BookRepository, BookRepository>();
        }     


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
            if(env.IsDevelopment(  ))
            {
                app.UseDeveloperExceptionPage();
            }
            */

            app.UseStaticFiles();

            //add mywwwroot folder
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Tempwwwroot")),
                RequestPath = "/Tempwwwroot"
            }); 
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            


        }
    }
    
    
}