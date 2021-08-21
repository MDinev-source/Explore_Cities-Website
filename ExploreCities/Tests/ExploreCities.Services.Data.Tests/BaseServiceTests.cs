namespace ExploreCities.Services.Data.Tests
{
    using System;
    using System.Reflection;

    using ExploreCities.Data;
    using ExploreCities.Data.Common;
    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models;
    using ExploreCities.Data.Repositories;
    using ExploreCities.Services.Mapping;
    using ExploreCities.Services.Messaging;
    using ExploreCities.Web.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class BaseServiceTests : IDisposable
    {
        protected BaseServiceTests()
        {
            var services = this.SetServices();
            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        protected IServiceProvider ServiceProvider { get; set; }

        protected ApplicationDbContext DbContext { get; set; }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(
                opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services
                          .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                          {
                              options.Password.RequireDigit = false;
                              options.Password.RequireLowercase = false;
                              options.Password.RequireUppercase = false;
                              options.Password.RequireNonAlphanumeric = false;
                              options.Password.RequiredLength = 6;
                          })
                          .AddEntityFrameworkStores<ApplicationDbContext>()
                          .AddDefaultTokenProviders();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<IGetEnumsDataService, GetEnumsDataService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<IDistrictsService, DistrictsService>();
            services.AddTransient<IDistrictViewsService, DistrictViewsService>();
            services.AddTransient<IDistrictViewObjectsService, DistrictViewObjectsService>();
            services.AddTransient<IPicturesService, PicturesService>();

            // AutoMapper
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            var context = new DefaultHttpContext();
            services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor { HttpContext = context });

            return services;
        }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            this.SetServices();
        }
    }
}
