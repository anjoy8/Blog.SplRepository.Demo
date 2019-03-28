using AutoMapper;
using Blog.SplRepository.Core.Interfaces;
using Blog.SplRepository.Infrastructure;
using Blog.SplRepository.Infrastructure.Repositories;
using Blog.SplRepository.Infrastructure.Seed;
using Blog.SplRepository.Infrastructure.Validators;
using Blog.SplRepository.Infrastructure.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Blog.SplRepository.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private const string ApiName = "Blog.SplRepository.Api";
        private const string version = "V1";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation();
            services.AddAutoMapper(typeof(Startup));


            services.AddScoped<DBSeed>();
            services.AddScoped<DbContext>();

            services.AddTransient<IValidator<BlogArticleAddViewModel>, BlogArticleAddOrUpdateViewModelValidator<BlogArticleAddViewModel>>();
            services.AddTransient<IValidator<BlogArticleUpdateViewModel>, BlogArticleAddOrUpdateViewModelValidator<BlogArticleUpdateViewModel>>();


            services.AddScoped<IBlogArticleRepository, BlogArticleRepository>();

            #region Swagger UI Service

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new Info
                {
                    // {ApiName} 定义成全局变量，方便修改
                    Version = version,
                    Title = $"{ApiName} 接口文档",
                    Description = $"{ApiName} HTTP API " + version,
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Blog.SplRepository.Api", Email = "Blog.SplRepository.Api@xxx.com", Url = "https://www.jianshu.com/u/94102b59cc2a" }
                });


            });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{ApiName} {version}");

                c.RoutePrefix = ""; //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉
            });

            app.UseMvc();
        }
    }
}
