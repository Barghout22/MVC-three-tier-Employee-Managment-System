using EmployeeCrud.BLL.ModelVm.Employee;
using EmployeeCrud.BLL.Response;

namespace EmployeeCrud.BLL.Service.Abstraction
{
    public interface IEmployeeService
    {
        Response<List<GetEmployeeVm>> GetActiveEmployee();
        Response<List<GetEmployeeVm>> GetInActiveEmployee();
        Response<GetEmployeeVm> GetEmployeeById(int Id);
        Response<CreateEmployeeVm> Create(CreateEmployeeVm model);
        Response<UpdateEmployeeVm> Update(UpdateEmployeeVm model);
        Response<GetEmployeeVm> Delete(GetEmployeeVm getEmployeeVm);

    }
}
