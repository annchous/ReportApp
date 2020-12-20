using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using MatBlazor;
using Microsoft.EntityFrameworkCore;
using ReportApp.Core.Interfaces;
using ReportApp.Core.Mappers;
using ReportApp.Core.Services;
using ReportApp.DAL.Context;
using ReportApp.DAL.Interfaces;
using ReportApp.DAL.Repositories;

namespace ReportApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ReportAppContext>(options => options.UseSqlServer(connection));
            services.AddCors();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaskMappingProfile());
                mc.AddProfile(new ReportMappingProfile());
                mc.AddProfile(new EmployeeMappingProfile());
                mc.AddProfile(new TaskChangeMappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ITaskChangeRepository, TaskChangeRepository>();
            services.AddTransient<ITaskChangeService, TaskChangeService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
