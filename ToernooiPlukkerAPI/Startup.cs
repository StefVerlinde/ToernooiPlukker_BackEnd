using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ToernooiPlukkerAPI.Data;
using ToernooiPlukkerAPI.Data.Repositories;
using ToernooiPlukkerAPI.Models;

namespace ToernooiPlukkerAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("ApplicationContext")));

            services.AddScoped<ToernooiPlukkerDataInitializer>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddOpenApiDocument();

            //Cors is a mechanism to tell a browser to let a web app running at one origin have permission to acces selected resources from a server at a different origin
            services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ToernooiPlukkerDataInitializer toernooiPlukkerDataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwaggerUi3();
            app.UseSwagger();
            app.UseCors("AllowAllOrigins");

            toernooiPlukkerDataInitializer.InitializeData();
        }
    }
}
