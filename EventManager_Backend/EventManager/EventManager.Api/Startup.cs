using System;
using AutoMapper;
using EventManager.Api.AutoMapper;
using EventManager.Domain.IServices;
using EventManager.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EventManager.Domain;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventManager.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new ModelStateValidationFilter());
            })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddCors();

            services.AddAutoMapper(x => {
                x.AddProfile(new LectureProfile());
                x.AddProfile(new EventProfile());
                x.AddProfile(new ReviewProfile());
            });

            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ILectureService, LectureService>();
            services.AddTransient<IReviewService, ReviewService>();

            services.AddDbContext<EventManagerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            app.UseCors(builder => builder
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowAnyOrigin()
                );
        }

        public class ModelStateValidationFilter : Attribute, IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                if (!context.ModelState.IsValid)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }

            public void OnActionExecuted(ActionExecutedContext context) { }
        }
    }
}
