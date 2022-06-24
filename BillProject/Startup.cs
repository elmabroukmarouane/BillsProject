using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BillProject.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BillProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // AddTransient c'était faux, j'étais un peu stressé avec l'entretien tout à l'heure car le service serait créé à chaque fois qu'on le demande requête ce n'est pas ce qu'on veut dans notre cas
            // AddScoped aussi ça ne sera pas la meilleure configuration car le service serait créé une seule fois par requête
            // AddSingleton c'est la meilleure configuration pour notre cas car ça va être la première fois quand on demande la requête et on aura une seule instance
            services.AddSingleton<IBillService, BillService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
