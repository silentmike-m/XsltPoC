namespace SilentMike.XsltPoC.WebApi
{
    using System.Reflection;
    using MassTransit;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Hosting;
    using Serilog;
    using SilentMike.XsltPoC.WebApi.Application.Users.Consumers;
    using SilentMike.XsltPoC.WebApi.Services;

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

            services.AddSingleton<IFileProvider>(new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly()));
            services.AddTransient<XmlService>();

            services.AddMassTransit(configure =>
            {
                configure.AddConsumer<SendUserEmailConsumer>();
                configure.AddConsumer<GetUserHtmlEmailConsumer>();

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
                    //cfg.ReceiveEndpoint("send-email", e =>
                    //{
                    //    e.ConfigureConsumer<SendUserEmailConsumer>(context);
                    //});
                });
            });

            services.AddMassTransitHostedService();

            services.AddHttpContextAccessor();

            //services.ConfigureSwaggerGen(c =>
            //{
            //    c.CustomSchemaIds(s => s.FullName);
            //});

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "XsltPoC WebApi",
            //        Version = "v1",
            //    });
            //});
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
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "XsltPoC WebApi v1"));
            }

            app.UseHealthChecks("/health");

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
