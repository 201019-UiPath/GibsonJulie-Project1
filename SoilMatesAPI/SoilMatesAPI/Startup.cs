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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SoilMatesDB;
using SoilMatesLib;
using SoilMatesResources;

namespace SoilMatesAPI
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
            services.AddDbContext<SoilMatesContext>(options => options.UseNpgsql(Configuration.GetConnectionString("SoilMatesDB")));

            services.AddScoped<IRepository, DBrepo>();

            //Customer 
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepo, DBrepo>();
            services.AddScoped<ICustomerMapper, Mapper>();

            //Manager
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IManagerRepo, DBrepo>();
            services.AddScoped<IManagerMapper, Mapper>();

            //Orders
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrdersRepo, DBrepo>();
            services.AddScoped<IOrderMapper, Mapper>();

            services.AddScoped<IOrderProductService, OrderProductService>();
            services.AddScoped<IOrderProductRepo, DBrepo>();
            services.AddScoped<IOrderProductMapper, Mapper>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepo, DBrepo>();
            services.AddScoped<IProductMapper, Mapper>();




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
