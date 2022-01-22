using Core_MVC_CRUD.Infrastructure.Context;
using Core_MVC_CRUD.Infrastructure.Repositories.Concrete;
using Core_MVC_CRUD.Infrastructure.Repositories.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_MVC_CRUD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddControllersWithViews();
            // DI ve IoC prensiplerine uymam�z gerekir. Bu metodun i�inde IoC Container' � y�netece�iz. IoC Container, Core' un i�erisine built-in olarak g�m�l�d�r. Ba��ml�l��a neden olacak s�n�flar buradan register ve resolve edilir. 
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Uygulama i�inde ba��ml�l��a neden olacak s�n�flar� built-in IoC Conteiner i�erisine resolve ettik. B�ylelikle CategoryRepository.cs s�n�f�n� new' lemek yerine onun atas� olan ICategoryRepository.cs intefacesini inject ettik. 
            // AddScoped() --> Her request ba��na bir nesne �retir. Talep sonland���nda nesneleri dispose eder.
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
