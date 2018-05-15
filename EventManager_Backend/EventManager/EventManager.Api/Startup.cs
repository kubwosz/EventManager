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
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddCors();

            services.AddAutoMapper(x=>x.AddProfile(new MappingsProfile()));

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
    }
}
