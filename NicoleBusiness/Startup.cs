using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NicoleBusiness.Services;
using NicoleBusiness.Contracts;
using NicoleBusiness.Models;

namespace NicoleBusiness
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
            // Core Services
            services.AddMvc();
            
            var connection = @"Host=localhost;Database=nicolesbusiness;Username=chelbling;Password=sharpie7";
            services.AddDbContext<NicoleBusinessDbContext>(options => options.UseNpgsql(connection));
            
            // Application Services
            services.AddTransient<IIncomeService, IncomeService>();
            services.AddTransient<IExpenseService, ExpenseService>();
            services.AddTransient<ITransactionTypeService, TransactionTypeService>();


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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
