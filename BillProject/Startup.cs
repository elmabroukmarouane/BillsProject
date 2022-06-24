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

            // AddTransient c'�tait faux, j'�tais un peu stress� avec l'entretien tout � l'heure car le service serait cr�� � chaque fois qu'on le demande requ�te ce n'est pas ce qu'on veut dans notre cas
            // AddScoped aussi �a ne sera pas la meilleure configuration car le service serait cr�� une seule fois par requ�te
            // AddSingleton c'est la meilleure configuration pour notre cas car �a va �tre la premi�re fois quand on demande la requ�te et on aura une seule instance
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
