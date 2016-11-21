namespace Voting.Web.Api
{
    using System;
    using Filters;
    using Implementation.Authentication;
    using Implementation.Session;
    using Implementation.User;
    using Library.Authentication;
    using Library.Session;
    using Library.User;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using StructureMap;

    public class Startup
    {
        public Startup(IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(setup =>
                {
                    setup.Filters.Add(new TokenAuthorizationFilterFactory());
                });

            return this.ConfigureInversionOfControl(services);
        }

        public IServiceProvider ConfigureInversionOfControl(IServiceCollection services)
        {
            var container = new Container();

            container.Configure((ConfigurationExpression config) =>
            {
                config
                    .For<TimeSpan>()
                    .Add(() => TimeSpan.FromMinutes(30)) // TODO: read from config
                    .Named("SessionDuration");
                config
                    .ForSingletonOf<ISessionDurationProvider>()
                    .Use<SessionDurationProvider>()
                    .Ctor<TimeSpan>("SessionDuration");
                config
                    .ForSingletonOf<ISessionRepository>()
                    .Use<InMemorySessionRepository>();
                config
                    .ForSingletonOf<IUserRepository>()
                    .Use<InMemoryUserRepository>();
                config
                    .ForSingletonOf<IUserAuthenticationService>()
                    .Use<InMemoryUserAuthenticationService>();

                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment environment, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));

            if (environment.IsDevelopment())
            {
                loggerFactory.AddDebug();
            }

            applicationBuilder.UseMvc();
        }
    }
}