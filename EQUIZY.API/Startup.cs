using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EQUIZY.API.Extensions;
using EQUIZY.API.JWTSettings;
using EQUIZY.API.Services;
using EQUIZY.Core;
using EQUIZY.Core.Models;
using EQUIZY.Core.Repositories;
using EQUIZY.Core.Services;
using EQUIZY.Data;
using EQUIZY.DataMongoDB.Repository;
using EQUIZY.DataMongoDB.Settings;
using EQUIZY.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace EQUIZY.API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
                                  });
            });
            services.AddControllers();
            //SQL Configuration
            services.AddDbContext<MyEquizyDbContext>(options => options.UseMySql(Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("EQUIZY.Data")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosAzure>();
            services.AddTransient<IStateProvinceService, StateProvinceService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IUserAddressListService, UserAddressListService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ITypeAddressService, TypeAddressService>();
            services.AddTransient<ITopicEvaluationService, TopicEvaluationService>();
            services.AddTransient<ITypeEvaluationService, TypeEvaluationService>();
            services.AddTransient<ICategoryEvaluationService, CategoryEvaluationService>();
            services.AddTransient<IEvaluationService, EvaluationService>();
            services.AddTransient<IProfessorProfessorEvaluationListService, ProfessorEvaluationListService>();
            services.AddTransient<IQuizQuestionService, QuizQuestionService>();
            services.AddTransient<IQuestionListService, QuestionListService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IAnswerListService, AnswerListService>();
            services.AddIdentity<AppUser, AppUserRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
                })
            .AddEntityFrameworkStores<MyEquizyDbContext>()
            .AddDefaultTokenProviders();
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddAuth(jwtSettings);
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //End SQL Config

            //Mongo config
            services.Configure<Settings>(
            options =>
            {
                options.ConnectionString = Configuration.GetValue<string>("MongoDB:ConnectionString");
                options.Database = Configuration.GetValue<string>("MongoDB:Database");
            });
            services.AddSingleton<IMongoClient, MongoClient>(
            _ => new MongoClient(Configuration.GetValue<string>("MongoDB:ConnectionString")));
            services.AddTransient<IDatabaseSettings, DatabaseSettings>();
            services.AddScoped<IComposerRepository, ComposerRepository>();
            services.AddTransient<IComposerService, ComposerService>();
            //End Mongo config

            //Swagger config
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Put title here",
                    Description = "DotNet Core Api 3 - with swagger"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT containing userid claim",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                }); var security =
                     new OpenApiSecurityRequirement
                     {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                },
                UnresolvedReference = true
            },
            new List<string>()
        }
                     }; c.AddSecurityRequirement(security);
            });
            //End Swagger config

            //Automapper config
            services.AddAutoMapper(typeof(Startup));
            //End Automapper config
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

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Swagger config
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EQUIZY V1");
            });
            //End Swagger config
            app.UseAuth();
        }
    }
}
