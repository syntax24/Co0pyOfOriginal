using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using AccountManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using PersonalContractingParty.Config;
using ServiceHost.Areas.Admin.Pages.Company.FilePage;

namespace ServiceHost
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
            services.AddHttpContextAccessor();
            var connectionString = Configuration.GetConnectionString("MesbahDb");
            PersonalBootstrapper.Configure(services, connectionString);
            AccountManagementBootstrapper.Configure(services, connectionString);

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();

            services.AddTransient<IndexModel>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Index");
                    o.LogoutPath = new PathString("/Index");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                    
                    o.ExpireTimeSpan = TimeSpan.FromHours(10);
                    o.SlidingExpiration = true;

                });
            //services.AddAuthorization(options =>
            //    options.AddPolicy("AdminArea", builder =>builder.RequireRole(Roles.role)));

            services.AddAuthorization(options =>
                options.AddPolicy("AdminArea", builder => builder.RequireClaim("AccountId")));
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(option =>
            //    {
            //        option.LoginPath = "/Index";
            //        option.LogoutPath = "/Index";
            //        option.ExpireTimeSpan = TimeSpan.FromDays(1);

            //    });

            services.AddRazorPages(options => 
                options.Conventions.AuthorizeAreaFolder("Admin","/","AdminArea"));
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
                app.UseDeveloperExceptionPage();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();
        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();

            });
        }
    }
}
 