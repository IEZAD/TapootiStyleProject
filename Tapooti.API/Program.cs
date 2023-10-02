using System.Text;
using Tapooti.API.Config;
using _0_Framework.Domain.Sms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ShopManagment.Configuration;
using FileManagement.Configuration;
using Microsoft.IdentityModel.Tokens;
using AccountManagement.Configuration;
using Microsoft.AspNetCore.Mvc.Versioning;
using _0_Framework.Apllication.Extensions;
using _0_Framework.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Tapooti.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                builder.Host.UseSeriLog_Console();
            else
                builder.Host.UseSeriLog_SqlServer();

            var connectionString = builder.Configuration.GetConnectionString("Tapooti");

            builder.Services.Configure<KavenegarInfoViewModel>(builder.Configuration.GetSection(key: "KavenegarInfo"));

            #region Bootstrapper
            ShopManagmentBootstrapper.Configure(builder.Services, connectionString);
            FileManagementBootstrapper.Configure(builder.Services, connectionString);
            AccountManagementBootstrapper.Configure(builder.Services, connectionString);
            _0_FrameworkManagementBootstrapper.Configure(builder.Services, connectionString);
            #endregion

            /**************************************************************/

            #region Services
            // Add services to the container.
            builder.Services.AddControllers();

            //Swagger Config
            void AddSwaggerGen()
            {
                //Api Versioning Config
                builder.Services.AddApiVersioning(options =>
                {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ReportApiVersions = true;
                    options.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader("api-version"));
                });

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();

                builder.Services.AddSwaggerGen(options =>
                {
                    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Tapooti.xml"), true);
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Tapooti API", Version = "v1" });

                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer B522887F-E9F8-455C-AE82-5161CF1212DD')",
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme,
                        },
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = JwtBearerDefaults.AuthenticationScheme,
                                },
                            },
                            Array.Empty<string>()
                        }
                    });
                });
            }

            //JWT Token Config
            void JWTTokenConfig()
            {
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(configureOptions =>
                {
                    configureOptions.SaveToken = true; // HttpContext.GetTokenAsync();
                    configureOptions.RequireHttpsMetadata = false;
                    configureOptions.Events = new JwtBearerEvents()
                    {
                        OnForbidden = context =>
                        {
                            //log
                            //...
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            //log
                            //...
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            //log
                            //...
                            return Task.CompletedTask;
                        },
                        OnMessageReceived = context =>
                        {
                            //log
                            //...
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            //log
                            //...
                            return Task.CompletedTask;
                        },
                    };
                    configureOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireExpirationTime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    };
                });
            }

            //AutoMapper
            void ConfigureAutoMapper()
            {
                builder.Services.AutoMapperConfig();
            }

            void ConfigureClientServiceManager()
            {
                builder.Services.AddHttpClient();
            }

            //Services
            void ConfigureServicesManager()
            {
                AddSwaggerGen();
                JWTTokenConfig();
                ConfigureAutoMapper();
                ConfigureClientServiceManager();
            }

            //Call Services
            ConfigureServicesManager();
            #endregion

            /**************************************************************/

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tapooti API V1");
                });
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}