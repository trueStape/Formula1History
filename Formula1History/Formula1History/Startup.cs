using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Entities.Race;
using DAL.Entities.Team;
using DAL.Interfaces;
using DAL.Repositories;
using Formula1History.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Formula1History
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
            services.AddDbContext<DatabaseContext>
            (options => options.UseSqlServer(Configuration["ConnectionString:Formula1History"],
                b => b.MigrationsAssembly("Formula1History")));

            services.AddControllersWithViews();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Swagger
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "SoftLine Api", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            //TODO 3 Add Dependency life cycle (Dependency injection)

            /*
             * Registration Repository
             */

            //services.AddTransient<IPeople, PeopleRepository>();
            services
                .AddScoped<IDriverRepository, DriverRepository>()
                .AddScoped<IManagerRepository, ManagerRepository>()
                .AddScoped<IRaceRepository<RaceWeekendEntity>, RaceRepository<RaceWeekendEntity>>()
                .AddScoped<IRaceRepository<RaceYearEntity>, RaceRepository<RaceYearEntity>>()
                .AddScoped<ITeamRepository<TeamEntity>, TeamRepository<TeamEntity>>();

            /*
             * Registration services
             */
            services
                .AddScoped<IDriverService, DriverService>()
                .AddScoped<IRaceService, RaceService>()
                .AddScoped<ITeamService, TeamService>();


            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Swagger
            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(o => { o.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            //Serilog
            app.UseSerilogRequestLogging();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
