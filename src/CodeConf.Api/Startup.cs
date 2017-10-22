using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeConf.Api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CodeConf.Api
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
            services.AddMvc();

            services.AddDbContext<ConferenceContext>(
                options => options.UseSqlServer(
                    Configuration["ConnectionStrings:DB"],
                    sqlOptions => sqlOptions.EnableRetryOnFailure()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var logger = app.ApplicationServices.GetService<ILoggerFactory>().CreateLogger(nameof(Configure));

            logger.LogInformation("Seeding database... (this may take a while)");
            app.SeedDatabase();
            logger.LogInformation("Database seed complete.");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
