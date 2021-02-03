using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Data.Interfaces;
using WeatherApp.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace WeatherApp
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            services.AddTransient<IWeatherService, WeatherService>();
            services.AddTransient<IAutocompleteService, AutocompleteService>();
            services.AddScoped<IObservationRepository, SQLObservationsRepository>();
            services.AddSingleton<IFavoritesRepository, InMemoryFavoritesRepository>();
            services.AddControllers();
            services.AddDbContextPool<WeatherDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WeatherDatabase")));
            services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.Password.RequiredLength = 4;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
                    .AddEntityFrameworkStores<WeatherDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
