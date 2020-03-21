using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaBox.Storage.Databases;
using PizzaBox.Storage.Repositories;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client
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
            services.AddControllersWithViews();
            //I ADDED THIS
            services.AddDbContext<PizzaBoxDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("main")));
            services.AddScoped<PizzaBoxRepository>(); // lifetime of the application for all requests
            services.AddScoped<UserRepository>();
            services.AddScoped<StoreRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<PizzaRepository>();
            services.AddScoped<OrderPizzaRepository>();
            services.AddScoped<StorePizzaRepository>();
            //services.AddScoped<IRepository, PizzaBoxRepository>(); // lifetime of 1 request for all method calls
            //services.AddTransient<IRepository, PizzaBoxRepository>(); // lifetime of 1 method call within 1 request
              }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PizzaBoxDbContext dbContext)
        {
            dbContext.Database.Migrate();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
