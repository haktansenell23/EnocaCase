using Autofac;
using Autofac.Extensions.DependencyInjection;
using EnocaCase.API.BackgroundServices;
using EnocaCase.API.Middlewares;
using EnocaCase.API.Modules;
using EnocaCase.Repository;
using EnocaCase.Service.Mapper;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(

    x => x.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnectionString"),
    option =>
    option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name
    )));
//builder.Services.AddHangfire(x =>
//{

//    var option = new SqlServerStorageOptions
//    {
//        PrepareSchemaIfNecessary = true,    
//        QueuePollInterval = TimeSpan.FromMinutes(5),
//        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),    
//        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),   
//        UseRecommendedIsolationLevel = true,    
//        UsePageLocksOnDequeue=true,
//        DisableGlobalLocks = true,  


//    };

//}


//) ;
var hangfireConnectionStrings = builder.Configuration.GetConnectionString("HangfireMssqlConnectionString");
builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(hangfireConnectionStrings);
    //*/1 * * * *
    //0 * * * *
    RecurringJob.AddOrUpdate<CarrierReportsLogWriter>(x => x.CarrierReportsWriter(), "0 * * * *");
});
builder.Services.AddHangfireServer();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomException();
app.UseHttpsRedirection();
app.UseHangfireDashboard();
app.UseAuthorization();
app.MapControllers();

app.Run();
