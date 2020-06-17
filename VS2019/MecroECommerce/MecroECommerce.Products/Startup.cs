using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MecroECommerce.Products.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MecroECommerce.Products.Persistence;
using Microsoft.OpenApi.Models;
using Microsoft.Data.SqlClient;

namespace MecroECommerce.Products
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
            
            //Injection Local
            services.AddScoped<IProductService, ProductService>();

            //Injection Lib
            services.AddAutoMapper(typeof(Startup));
            
            //Db Connection 
            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProductsConnection")));
            //.UseInMemoryDatabase("Products"));

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MecroECommerce.Products", Version = "v1" });
            });

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MecroECommerce.Products V1");
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            var evolve = new Evolve.Evolve(new SqlConnection(Configuration.GetConnectionString("ProductsConnection")))
            {
                Locations = new[] { "DbMigrations" },
                IsEraseDisabled = true,
            };

            evolve.Migrate();


        }
    }
}
