using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reservation.BLL.Abstract;
using Reservation.BLL.Concreate;
using Reservation.Core.Repository;
using Reservation.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Reservation.Core.Repository.EntityFramework;
using Reservation.Core.Repository.EntityFramework.DAL.Abstract;
using Reservation.Core.Repository.EntityFramework.DAL.Concreate;
using Reservation.Core.Repository.InMemory.Abstract;
using Reservation.Core.Repository.InMemory.Concreate;
using FluentValidation.AspNetCore;
using Reservation.NotificationService;

namespace Reservation.Api
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
            services.AddControllers().AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<Startup>());
            //services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddDbContext<ReservationDBContext>();

            services.AddAutoMapper(typeof(AutoMapping));

            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            services.AddScoped<IReservationBusiness, ReservationBusiness>();
            services.AddScoped<ITableBusiness,TableBusiness>();

            services.AddScoped<IInMemoryTableRepository, InMemoryTableRepository>();
            services.AddScoped<IInMemoryReservationRepository, InMemoryReservationRepository>();

            services.AddScoped<IMailService, MailService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
