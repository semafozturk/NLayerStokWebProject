using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using Nlayer.Core.UnitOfWork;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWork;
using NLayer.Service.Mapping;
using NLayer.Service.Modules;
using NLayer.Service.Services;
using NLayer.Service.Validations;
using Serilog;
using Serilog.Core;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// FluentValidation
builder.Services.AddControllersWithViews()
    .AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductValidator>());

// AutooMapper
builder.Services.AddAutoMapper(typeof(MapProfile));

// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container=>container.RegisterModule(new RepoServiceModule()));

// db connection
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
Logger log = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt")
    //.Enrich.FromLogContext() //hariçten veri al?nacaksa kullan?l?r (username gibi)
    .CreateLogger();
builder.Host.UseSerilog(log);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
