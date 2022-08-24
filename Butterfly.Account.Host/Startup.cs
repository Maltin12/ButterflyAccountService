using Microsoft.AspNetCore.Mvc;
using Butterfly.Account.Host.Configurations;
using Butterfly.Account.Host.Filters;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Butterfly.Account.Host
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
            services.RegisterServices(Configuration);

            services.AddMvc(options =>
                {
                    options.Filters.Add<CustomExceptionFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .UseServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.AddServices();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}