using Microsoft.EntityFrameworkCore;
using ShopsPages.DAL;
using ShopsPages.Models;

namespace ShopsPages
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
            services.AddRazorPages().AddRazorRuntimeCompilation();

            string configuration = ConfigurationExtensions.GetConnectionString(this.Configuration, "DefaultConnection");
            services.AddDbContext<ShopsContext>(options => options.UseSqlServer(configuration));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/Shop/Error/{0}");
            app.UseExceptionHandler("/Shop/Error");
            if (!env.IsDevelopment())
            {
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
                    pattern: "{controller=Shop}/{action=Index}");
            });
        }
    }
}
