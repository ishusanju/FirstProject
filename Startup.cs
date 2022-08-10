using Mongohosting.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mongohosting.Model;
using Microsoft.Extensions.Options;
using APIExampleForMongoDb.Model;

namespace Mongohosting
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
            services.AddMvc();
            
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSingleton<EmployeeServices, EmployeeServices>();
          services.Configure<EmployeeDatabaseSettings>(Configuration.GetSection("EmployeeDatabaseSettings"));
            //services.AddSingleton<IEmployeeDatabaseSettings>(sp => sp.GetRequiredService<<IOptions<EmployeeDatabaseSettings>>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            //app.MapControllers();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.Run();
        }
    }
}
