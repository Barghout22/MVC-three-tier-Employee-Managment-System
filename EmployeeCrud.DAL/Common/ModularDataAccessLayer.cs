using EmployeeCrud.DAL.Repo.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeCrud.DAL.Common
{
    public static class ModularDataAccessLayer
    {
        public static IServiceCollection AddBussinessInDAL(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();

            services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            return services;
        }
    }
}
