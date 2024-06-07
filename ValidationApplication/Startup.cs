using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ValidationApplication.Data;
using ValidationApplication.Models;
using ValidationApplication.Resources;
using ValidationApplication.Validations;

namespace ValidationApplication
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
            //services.AddLocalization(options => options.ResourcesPath = "Resources");

            // we need to add this middleware in order to be able to resolve IStringLocalizer
            services.AddMvc()
                .AddDataAnnotationsLocalization(options =>
                {
                    // Using one resource string for multiple classes
                    //options.DataAnnotationLocalizerProvider = (type, factory) =>
                    //    factory.Create(typeof(ValidationMessages));
                });

            services.AddControllersWithViews();

            // Makes the Razor Pages available.
            services.AddRazorPages();

            services.AddDbContext<BookDbContext>(options =>
                options.UseInMemoryDatabase("book-db"));

            services.AddScoped<IValidator<FluentValidationBookModel>, CreateBookRequestValidator>();
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

            var supportedCultures = new[] { "en", "el" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[1])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            //Localization middleware
            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // Adds endpoints for Razor Pages.
                endpoints.MapRazorPages();
            });
        }
    }
}
