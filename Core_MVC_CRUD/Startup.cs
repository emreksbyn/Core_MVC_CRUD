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
            // DI ve IoC prensiplerine uymamýz gerekir. Bu metodun içinde IoC Container' ý yöneteceðiz. IoC Container, Core' un içerisine built-in olarak gömülüdür. Baðýmlýlýða neden olacak sýnýflar buradan register ve resolve edilir. 
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Uygulama içinde baðýmlýlýða neden olacak sýnýflarý built-in IoC Conteiner içerisine resolve ettik. Böylelikle CategoryRepository.cs sýnýfýný new' lemek yerine onun atasý olan ICategoryRepository.cs intefacesini inject ettik. 
            // AddScoped() --> Her request baþýna bir nesne üretir. Talep sonlandýðýnda nesneleri dispose eder.
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
