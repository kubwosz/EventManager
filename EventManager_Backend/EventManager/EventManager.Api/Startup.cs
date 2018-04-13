using AutoMapper;
using EventManager.Api.AutoMapper;
using EventManager.Domain.IServices;
using EventManager.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace EventManager.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(x=>x.AddProfile(new MappingsProfile()));
            services.AddMvc();

            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ILectureService, LectureService>();
            services.AddTransient<IReviewService, ReviewService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
