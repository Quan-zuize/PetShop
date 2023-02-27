

namespace PetShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddDistributedMemoryCache();           
            services.AddSession(cfg => {                    
                cfg.Cookie.Name = "cookie01";             
                cfg.IdleTimeout = new TimeSpan(0, 60, 0);    
            });
        }

        [Obsolete]
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env) 
        {
            app.UseSession();
        }
    }
}
