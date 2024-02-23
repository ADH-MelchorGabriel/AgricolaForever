using EYE.Servicio.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAT.Data;
using Seguridad.Interfaces;
using Seguridad.Options;
using Seguridad.Services;

namespace Empaque_y_embarque.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<SatContext>(option => option.UseMySQL(Configuration.GetConnectionString("sat")));
            services.AddDbContext<EyeContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));


            services.Configure<PasswordOptions>(options => Configuration.GetSection("PasswordOptions").Bind(options));

            services.AddSingleton<IPasswordServices, PasswordService>();

            services.AddAuthentication("TaurusAuth").AddCookie("TaurusAuth", config =>
            {
                config.Cookie.Name = "Taurus.Cookie";
                config.Cookie.MaxAge = System.TimeSpan.FromDays(365);
                config.LoginPath = "/Home/Login";
            });


            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();

               
            }
            else
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
