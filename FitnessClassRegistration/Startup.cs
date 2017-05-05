using ApplicationModels.FitnessApp.Models;
using AutoMapper;
using FitnessClassRegistration.CustomValidation;
using FitnessClassRegistration.Data;
using FitnessClassRegistration.IRepository;
using FitnessClassRegistration.Logic;
using FitnessClassRegistration.Models;
using FitnessClassRegistration.Models.ApplicationViewModels;
using FitnessClassRegistration.Repository;
using FitnessClassRegistration.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FitnessClassRegistration
{
    public class Startup
    {
        private IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<FitnessAppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("FitnessAppDatabase")));

            services.AddTransient<UserAndRoleSeedData>();

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                config.Cookies.ApplicationCookie.AccessDeniedPath = "/Home/Error";

            })
                .AddEntityFrameworkStores<FitnessAppDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(config =>
            {
                if (!_env.IsProduction())
                {
                    config.SslPort = 44391;
                }
                config.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddSingleton
                <IValidationAttributeAdapterProvider, CustomValidationAttributeAdapterProvider>();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            //Repository Services
            services.AddTransient<IRegistrationRecordRepository, RegistrationRecordRepository>();
            services.AddTransient<IFitnessClassRepository, FitnessClassRepository>();
            services.AddTransient<IFitnessClassTypeRepository, FitnessClassTypeRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IAnnouncementRepository, AnnouncementRepository>();

            //Logic services
            services.AddTransient<IFitnessClassLogic, FitnessClassLogic>();
            services.AddTransient<IFitnessClassTypeLogic, FitnessClassTypeLogic>();
            services.AddTransient<IInstructorLogic, InstructorLogic>();
            services.AddTransient<ILocationLogic, LocationLogic>();
            services.AddTransient<IRegistrationRecordLogic, RegistrationRecordLogic>();
            services.AddTransient<IAnnouncementLogic, AnnouncementLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            UserAndRoleSeedData identitySeeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            Mapper.Initialize(config =>
            {
                config.CreateMap<FitnessClassEditView, FitnessClass>().
                    ForMember(
                        dest => dest.FitnessClassType,
                        opt => opt.Ignore()
                    ).
                    ForMember(
                        dest => dest.Instructor,
                        opt => opt.Ignore()
                    ).
                    ForMember(
                        dest => dest.Location,
                        opt => opt.Ignore()
                    );

                config.CreateMap<FitnessClassListView, FitnessClass>().
                    ForMember(
                        dest => dest.Instructor_Id,
                        opt => opt.MapFrom(src => src.Instructor.Id)
                    ).
                    ForMember(
                        dest => dest.Location_Id,
                        opt => opt.MapFrom(src => src.Location.Id)
                    ).
                    ForMember(
                        dest => dest.FitnessClassType_Id,
                        opt => opt.MapFrom(src => src.FitnessClassType.Id)
                    );

                config.CreateMap<FitnessClass, FitnessClassEditView>();
                config.CreateMap<FitnessClass, FitnessClassListView>();
                config.CreateMap<FitnessClass, FitnessClassSignUpView>();
                config.CreateMap<FitnessClassType, FitnessClassTypeView>().ReverseMap();
                config.CreateMap<Instructor, InstructorView>().ReverseMap();
                config.CreateMap<Location, LocationView>().ReverseMap();
                config.CreateMap<RegistrationRecord, RegistrationRecordView>().ReverseMap();
                config.CreateMap<Announcement, AnnouncementView>().ReverseMap();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });

            identitySeeder.Seed().Wait();
        }
    }
}
