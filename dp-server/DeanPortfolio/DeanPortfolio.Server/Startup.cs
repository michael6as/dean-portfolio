using DeanPortfolio.Server.DAL;
using DeanPortfolio.Server.Routing;
using DeanPortfolio.Server.Routing.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace DeanPortfolio.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            // Initialize all classes instances for the BL and DAL
            FinanceDb finance = new FinanceDb();
            MailDb mails = new MailDb();
            var mailHandler = new MailHandler("michael95.as@gmail.com", "Michael", "Miki2995*", mails.UserMailRecipients);
            var rContainer = new RouteContainer(mailHandler, "Finance Route was used and this is the result");
            var routes = new Dictionary<string, IRoute>()
            {
                {"finance", new FinanceRoute(rContainer,finance.MoneyList ) }
            };
            services.AddSingleton<IRequestRouter>(new SimpleRequestRouter(routes));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
