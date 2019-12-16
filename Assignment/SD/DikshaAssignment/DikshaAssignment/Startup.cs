using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using DikshaAssignment.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

using Microsoft.EntityFrameworkCore;

namespace DikshaAssignment
{
    public class Startup
    {
        // Created the constructor to inject the IConfiguration interface to access the methods.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddRazorPages();  // added for mvc razor pages
             services.AddControllers(); // added for using controllers

            //Added to set the version compatibility
             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
             // added to connect to the db
            //  services.AddDbContext<EmployeeDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myConncectionString")));
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

           // Enabled the middleware to serve the generated swagger as a JSON endpoint 
            app.UseSwagger();
            
            // Enabled the middleware to serve the swagger UI using  (Htnl, Css, js..etc)
            // specifying the swagger endpoint
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DikshaAssignment");
            });
        }
    }
}
