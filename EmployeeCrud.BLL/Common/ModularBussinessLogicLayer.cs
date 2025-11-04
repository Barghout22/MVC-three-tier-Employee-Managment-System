using EmployeeCrud.BLL.Mapper;
using EmployeeCrud.BLL.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeCrud.BLL.Common
{
    public static class ModularBussinessLogicLayer
    {
        public static IServiceCollection AddBussinessInPL(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService,EmployeeService>();
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            services.AddScoped<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
