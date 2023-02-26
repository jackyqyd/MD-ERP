using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using NLog.Web;
using NLog;
using MDERP.Web.API.Db;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MDERP.Business.Extensions.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region NLog
var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables().Build();
LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
var logger = NLog.Web.NLogBuilder.ConfigureNLog(LogManager.Configuration).GetCurrentClassLogger();
builder.Host.UseNLog();
#endregion
builder.Services.AddControllers();
builder.Services.AddSqlsugarSetup(builder.Configuration);

#region Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MDERP WEB API", Version = "v1" });

    c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "bearerAuth"
        }
        },
        new string[] { }
    }
    });
});
#endregion

#region Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModuleRegister()));
#endregion

var app = builder.Build();
#region cors
app.UseCors(x => x.SetIsOriginAllowed(_ => true)
.AllowAnyMethod()
.AllowAnyHeader()
.AllowCredentials()
);
#endregion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

app.Run();
