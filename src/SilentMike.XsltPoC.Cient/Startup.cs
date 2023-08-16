namespace SilentMike.XsltPoC.Cient
{
    using System.Reflection;
    using System.Text.Json.Serialization;
    using MassTransit;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Serilog;
    using SilentMike.XsltPoC.Shared.Interfaces;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddSerilog());
            services.AddHealthChecks();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMassTransit(configure =>
            {
                var options = new RabbitMqOptions();
                this.Configuration.GetSection(RabbitMqOptions.SectionName).Bind(options);

                configure.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(options.HostAddress, host =>
                    {
                        host.Username(options.Username);
                        host.Password(options.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
                configure.AddRequestClient<IGetUserHtmlEmailRequest>();

            });
            services.AddMassTransitHostedService();

            services.AddHttpContextAccessor();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.ConfigureSwaggerGen(c =>
            {
                c.CustomSchemaIds(s => s.FullName);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "XsltPoC Client",
                    Version = "v1",
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                context.Request.PathBase = new PathString("/api");
                await next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "XsltPoC Client v1"));
            }

            app.UseHealthChecks("/health");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
