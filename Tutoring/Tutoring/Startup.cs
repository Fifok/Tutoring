using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tutoring.Controllers;
using Tutoring.Models;
using Tutoring.Models.Validators;
using TutoringLib;

namespace Tutoring
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _environment = environment;
            Configuration = configuration;
        }

        private readonly IHostEnvironment _environment;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();

            services.AddDbContext<TutoringContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dev")));
            //services.AddSingleton<IRepository<User>, MockUserRepository>();
            services.AddTransient<IValidator<LoginViewModel>, LoginVMValidator>();
            services.AddTransient<IValidator<SignupViewModel>, SignupVMValidator>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.Cookie.HttpOnly = true;
                    o.Cookie.SecurePolicy = _environment.IsDevelopment()
                        ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                    o.Cookie.SameSite = SameSiteMode.Strict;
                    o.Cookie.Name = "YourAuthCookie";
                    o.LoginPath = "/user/login";
                    o.LogoutPath = "/user/logout";
                });
            services.Configure<CookiePolicyOptions>(o =>
            {
                o.MinimumSameSitePolicy = SameSiteMode.Strict;
                o.HttpOnly = HttpOnlyPolicy.None;
                o.Secure = _environment.IsDevelopment()
                    ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
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
