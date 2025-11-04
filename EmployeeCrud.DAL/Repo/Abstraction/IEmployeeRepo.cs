using EmployeeCrud.DAL.Entity;
using System.Linq.Expressions;

namespace EmployeeCrud.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        bool Add(Employee employee);
        bool Edit(int Id,Employee employee);
        bool ToggleStatus(int Id);
        Employee GetEmployeeById(int Id);
        List<Employee> GetAllEmployees(Expression<Func<Employee, bool>>? Filter = null);

    }
}
