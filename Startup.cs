using System;
using Hospital.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hospital
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
            services.AddControllers();
            
            //Add singleton pattern since i am using mockdata instead of a database -- My services needs to know Mockdoctorsrepo needs to be based upon the created interfaces

            services.AddSingleton<IDoctorsRepo,MockDoctorsRepo>();
            services.AddSingleton<IPatientsRepo,MockPatientsRepo>();
            services.AddSingleton<IAdmissionsRepo,MockAdmissionsRepo>();

            //Added dependency Injection -- Just swap MockDoctorsREpo out for a other data location such as a SQLRepo 
            //services.AddScoped<IDoctorsRepo,MockDoctorsRepo>(); -- Should be used when dealing with http request using a database. Using singleton in this case
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
