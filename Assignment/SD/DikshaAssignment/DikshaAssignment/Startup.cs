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
using DikshaAssignment.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using DikshaAssignment.Services.Interface;
using DikshaAssignment.Services.Service;
using DikshaAssignment.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

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
            // Added to resolve the service dependency injection problem
             services.AddDbContext<EmployeeDBContext>(ServiceLifetime.Scoped);
             
             services.AddRazorPages();

             services.AddControllers();
            
             //Added to set the version compatibility
             // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
             services.AddMvc(option => option.EnableEndpointRouting = false);
             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);    
                            
             //Registering interface and services
             services.AddScoped(typeof(IEntityBaseRepository<>), typeof(EntityBaseRepository<>));
             services.AddScoped<IEmployeeService, EmployeeService>();


            // added to connect to the db
            //  services.AddDbContext<EmployeeDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myConncectionString")));
            // Register the Swagger generator, defining 1 or more Swagger documents
             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); //allowing to use static files

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Employee/Index");
                app.UseHsts();
            }

            app.UseRouting();
          
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employee}/{action=Index}/{id?}");
            });


            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapRazorPages();
            // });

           
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
