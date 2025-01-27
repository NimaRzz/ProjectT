using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Contexts;
using Project.Mvc.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseContext"))
);

builder.Services.AddMvc();

RegisterServices(builder.Services);

var app = builder.Build();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapDefaultControllerRoute();


app.Run();

static void RegisterServices(IServiceCollection services)
{
    DependencyContainer.RegisterServices(services);
}