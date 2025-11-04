using System.Linq.Expressions;

namespace EmployeeCrud.DAL.Repo.Abstraction
{
    public interface IDepartmentRepo
    {
        bool Add(Department department);
        bool Edit(int Id,Department department);
        bool ToggleStatus(int Id);
        Department GetDepartmentById(int Id);
        List<Department> GetAll(Expression<Func<Department, bool>>?Filter=null);
    }
}
