

using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Quartz;
using Space.Imdb.Api.Models.Mapping;
using Space.Imdb.Api.Models.Responses;
using Space.Imdb.Bll.Contracts.Interfaces.Service;
using Space.Imdb.Bll.Contracts.Models.Email;
using Space.Imdb.Bll.Contracts.Models.Mapping;
using Space.Imdb.Bll.Jobs;
using Space.Imdb.Bll.Service;
using Space.Imdb.Infrastructure.Contracts.Interfaces.Services;
using Space.Imdb.Infrastructure.Contracts.Models.Config;
using Space.Imdb.Infrastructure.Infrastructre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Space.Imdb.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddFluentValidation
            (
                i => i.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            )
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = c =>
                {
                    var errors = string.Join(string.Empty, c.ModelState.Values.Where(i => i.Errors.Count > 0)
                        .SelectMany(e => e.Errors)
                        .Select(e => e.ErrorMessage));

                    return new BadRequestObjectResult(Response.Fail(errors));
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Space.Imdb.Api", Version = "v1" });
            });

            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                q.ScheduleJob<NotificationJob>
                (
                    tg => tg.WithIdentity("NotificationTrigger", "NotificationTrigger")
                            .WithCronSchedule("0 30 15 ? * * *", x => x.InTimeZone(TimeZoneInfo.Utc))
                            .ForJob("NotificationJob", "NotificationJob")
                );
            });
            services.AddQuartzServer(options =>
            {
                options.WaitForJobsToComplete = true;
            });

            services.AddDbContextFactory<ImdbMovieContext>(option => option.UseSqlServer(Configuration.GetValue<string>("ConnectionConfig:ConnectionString"), sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
            }));


            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingApiProfile());
                mc.AddProfile(new MappingServiceProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.Configure<ImdbConfig>(Configuration.GetSection("ImdbConfig"));
            services.Configure<SmtpConfig>(Configuration.GetSection("SmtpConfig"));
            services.Configure<EbMailConfig>(Configuration.GetSection("EbMailConfig"));
            services.AddSingleton<IImdService, ImdService>();
            services.AddSingleton<IImdbUnitOfWork, ImdbUnitOfWork>();
            services.AddSingleton<IWatchListService, WatchListService>();
            services.AddSingleton<INotificationsService, NotificationsService>();
            services.AddSingleton<IEmailSenderService, EmailSenderService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Space.Imdb.Api"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
