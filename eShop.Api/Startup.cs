 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.Api.Interfaces;
using eShop.Api.Services;
using eShop.DAL;
using eShop.DAL.Repositories;
using eShop.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace eShop.Api
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
           // var cs = Configuration.GetSection("ConnectionStrings").Value;
            services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("shop")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddSingleton<ISeeder, Seeder>();// persists for the whole running duration of the app
                    //.AddScoped persists only for the duration of a single http call
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
