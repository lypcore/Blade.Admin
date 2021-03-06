﻿using System;
using System.Linq;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using EFCore.Sharding;

using NSwag;

using Blade.Util;
using Blade.Util.DI;
using Blade.Service;
using Quartz.Impl;
using Quartz;
using Blade.Service.QuartzManage;
using Quartz.Spi;
using Microsoft.Extensions.Hosting;

namespace Blade.Api
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
            services.AddFxServices();
            services.AddAutoMapper();
            #region 注入 Quartz调度类
            //services.AddSingleton<QuartzStartup>();
            //services.AddTransient<QuartzTestJob>();
            //注册ISchedulerFactory的实例。
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<IJobFactory, IOCJobFactory>();
            #endregion
            services.AddEFCoreSharding(config =>
            {
                var dbOptions = Configuration.GetSection("Database:BaseDb").Get<DatabaseOptions>();

                config.UseDatabase(dbOptions.ConnectionString, dbOptions.DatabaseType);
                config.SetEntityAssembly(GlobalData.FXASSEMBLY_PATTERN);
            });
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidFilterAttribute>();
                options.Filters.Add<GlobalExceptionFilter>();
            })
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.GetType().GetProperties().ForEach(aProperty =>
                {
                    var value = aProperty.GetValue(JsonExtention.DefaultJsonSetting);
                    aProperty.SetValue(options.SerializerSettings, value);
                });
            });
            services.AddHttpContextAccessor();

            //swagger
            services.AddOpenApiDocument(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Blade API";
                    document.Info.Description = "Blade.Admin 接口文档";
                    document.Info.TermsOfService = "无";
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = "我的邮箱",
                        Email = "1103354424@qq.com",
                        Url = "https://i.csdn.net/#/uc/profile"
                    };
                    document.Info.License = new OpenApiLicense
                    {
                        Name = "我的博客",
                        Url = "https://i.csdn.net/#/uc/profile"
                    };
                };
                settings.AddSecurity("身份认证Token", Enumerable.Empty<string>(), new OpenApiSecurityScheme()
                {
                    Scheme = "bearer",
                    Description = "Authorization:Bearer {your JWT token}<br/><b>授权地址:/BaseManage/Home/SubmitLogin</b>",
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Type = OpenApiSecuritySchemeType.Http
                });
            });
            //载入配置
            LoadSettings(Configuration);
        }
        private void LoadSettings(IConfiguration config)
        {
            string dbConnStr = config.GetSection("Database:BaseDb")["ConnectionString"];
            string dbType = config.GetSection("Database:BaseDb")["DatabaseType"];
            // 数据库配置
            //Sugar.Utility.DBHelper.ReSetConnst(dbConnStr, new string[] { dbConnStr });
            Sugar.Utility.DBHelper.ReSetConnst(dbConnStr);
            Sugar.Utility.DBHelper.GetDbType(dbType);
        }
        private void ConfigHelperOnChanged(object sender, EventArgs e)
        {
            ILoggerFactory factory = AutofacHelper.GetService<ILoggerFactory>();
            ILogger<Startup> logger = factory.CreateLogger<Startup>();
            LoadSettings(ConfigHelper.Configuration);
            logger.LogInformation("配置文件有修改被重新载入！");
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime)
        {
            //允许body重用
            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            })
            .UseMiddleware<CorsMiddleware>()//跨域
            .UseDeveloperExceptionPage()
            .UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
                DefaultContentType = "application/octet-stream"
            })
            .UseRouting()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseOpenApi(); //添加swagger生成api文档（默认路由文档 /swagger/v1/swagger.json）
            app.UseSwaggerUi3();//添加Swagger UI到请求管道中(默认路由: /swagger).
            ConfigHelper.OnChanged += ConfigHelperOnChanged;
            //QuartzManager.Run();
            //获取前面注入的Quartz调度类
            var quartz = app.ApplicationServices.GetRequiredService<QuartzStartup>();
            appLifetime.ApplicationStarted.Register(() =>
            {
                quartz.Start().Wait(); //网站启动完成执行
            });

            appLifetime.ApplicationStopped.Register(() =>
            {
                quartz.Stop();  //网站停止完成执行

            });
        }
    }
}
