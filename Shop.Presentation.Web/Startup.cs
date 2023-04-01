using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Services;
using Shop.BusinessLogic.Services.Interfaces;
using Shop.DataAccess.Json;

namespace Shop.Presentation.Web
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc((options) => options.EnableEndpointRouting = false);
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IUnitOfWork, JsonUnitOfWork>();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private void DisableEndpointRouting(MvcOptions options)
        {
            options.EnableEndpointRouting = false;
        }
    }
}
