using Project.Application.Interfaces.FacadPatterns;
using Project.Application.Services.FiscalYear.FacadPattern;
using Project.Domain.Repository.FiscalYear;
using Project.Infrastructure.Contexts;
using Project.Infrastructure.Repositories.FiscalYear;

namespace Project.Mvc.Common
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Infrastructure Layout
            services.AddScoped<DataBaseContext>();
            services.AddScoped<IFiscalYearRepository, FiscalYearRepository>();

            //Application Layout
            services.AddScoped<IFiscalYearFacad, FiscalYearFacad>();
        }
    }
}
