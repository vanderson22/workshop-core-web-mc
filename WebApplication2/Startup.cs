using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using WebApplication2.Data;
using WebApplication2.Services;

namespace WebApplication2
{
    /// <summary>
    /// Executa on startup
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<WebApplication2Context>(options =>
                    //options.UseSqlServer(Configuration.GetConnectionString("WebApplication2Context")));
                    options.UseMySql(Configuration.GetConnectionString("WebApplication2Context"),
                    b => b.MigrationsAssembly("WebApplication2")));


            //registrando  serviço de seeding 
            //Injeção de dependências
            services.AddScoped<SeedingService>();

            //register new services
            services.AddScoped<SellerService>();
            services.AddScoped<DepartmentsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // A instancia de SeedingService é automatica por causa da injecao AddScoped
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seeding
            ) {

            //desenv
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //Executa o método seed
                seeding.Seed();
            } else { //Produção
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
