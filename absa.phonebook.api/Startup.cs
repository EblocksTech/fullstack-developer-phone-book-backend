using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using absa.phonebook.api.Data;
using absa.phonebook.api.Sevices;
using absa.phonebook.api.Stores;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace absa.phonebook.api
{
    public class Startup
    {

        /// <summary>
        ///     Instatiating the <see cref="CORS_POLICY"/>
        /// </summary>
        private readonly string CORS_POLICY = "CorsPolicy";

        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: CORS_POLICY, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddControllers().AddFluentValidation(fv =>
                  fv.RegisterValidatorsFromAssemblyContaining<Startup>()); 
            ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "absa.phonebook.api", Version = "v1" });
            });
            

            if (_environment.IsDevelopment())
            {
                var connectionString = Configuration["ConnectionStrings:Postgres"];
                services.AddDbContext<PhonebookContext>(options => options.UseNpgsql(connectionString));
            }
            else
            {
                var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNSTR");                
                services.AddDbContext<PhonebookContext>(options => options.UseNpgsql(connectionString));
            }
                       
            services.AddTransient<IPhonebookService, PhonebookService>();
            services.AddTransient<IEntryService, EntryService>();
            services.AddTransient<IPhonebookStore, PhonebookStore>();
            services.AddTransient<IEntryStore, EntryStore>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "absa.phonebook.api v1"));
            }

            app.UseCors(CORS_POLICY);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            UpdateDatabase(app);
        }

        /// <summary>
        ///     Updates the database with the latest migrations.
        /// </summary>
        /// <param name="app">A <see cref="IApplicationBuilder"/> representing the application builder.</param>
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PhonebookContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
