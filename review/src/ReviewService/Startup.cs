using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ReviewService.Data;
using ReviewService.Profiles;

namespace ReviewService
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
            var connectionString = System.Environment.GetEnvironmentVariable("REVIEW_DB_CONNECTION_STRING") ??
                Configuration.GetConnectionString("MigrationConnection");

            services.AddDbContext<ReviewServiceContext>(opt =>
                opt.UseNpgsql(connectionString)
            );

            services.AddControllers();

            services.AddAutoMapper(typeof(ReviewProfile));

            services.AddScoped<IReviewRepository, ReviewRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/api/reviews");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Use(async (context, next) =>
            {
                var token = context.Request.Headers["Authorization"];
                System.Console.WriteLine(token);
                await next.Invoke();
            });


        }
    }
}
