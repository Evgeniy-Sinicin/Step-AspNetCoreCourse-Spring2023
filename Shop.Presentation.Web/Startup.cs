using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.BusinessLogic.DataAccessInterfaces;
using Shop.BusinessLogic.Services;
using Shop.BusinessLogic.Services.Interfaces;
using Shop.DataAccess.Json;
using Shop.Presentation.Web.Middleware;
using System;

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
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddMvc((options) => options.EnableEndpointRouting = false)
                .WithRazorPagesRoot("/Areas");
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IUnitOfWork, JsonUnitOfWork>();
            services.AddSwaggerGen();
            services.AddSingleton<ISingletonGuidCreator, GuidCreator2>();
            services.AddScoped<IScopedGuidCreator, GuidCreator2>();
            services.AddTransient<ITransientGuidCreator, GuidCreator2>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var headerName = "MyHeader";
            var headerValue = "MyHeaderValue";

            app.UseDeveloperExceptionPage();
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI();
            //app.Use(async (httpContext, callNextMiddleware) =>
            //{
            //    var response = httpContext.Response;
            //    var hasHeader = response.Headers.ContainsKey(headerName);
            //    await callNextMiddleware();
            //    hasHeader = response.Headers.ContainsKey(headerName);
            //});
            //app.Use(async (httpContext, callNextMiddleware) =>
            //{
            //    var response = httpContext.Response;
            //    var hasHeader = response.Headers.ContainsKey(headerName);
            //    await callNextMiddleware();
            //    httpContext.Response.Headers.Add(headerName, headerValue);
            //    hasHeader = response.Headers.ContainsKey(headerName);
            //});
            app.UseMvcWithDefaultRoute();
        }
    }

    public interface IGuidCreator
    {
        public Guid GetGuid();
    }

    public interface ISingletonGuidCreator : IGuidCreator { }

    public interface IScopedGuidCreator : IGuidCreator { }

    public interface ITransientGuidCreator : IGuidCreator { }

    public class GuidCreator : ISingletonGuidCreator, IScopedGuidCreator, ITransientGuidCreator
    {
        private readonly Guid _guid;

        public GuidCreator() => _guid = Guid.NewGuid();

        public Guid GetGuid() => _guid;
    }

    public class GuidCreator2 : ISingletonGuidCreator, IScopedGuidCreator, ITransientGuidCreator
    {
        private readonly Guid _guid;

        public GuidCreator2() => _guid = Guid.NewGuid();

        public Guid GetGuid() => Guid.Parse("12345678-1234-1234-1234-123456789123");
    }
}
