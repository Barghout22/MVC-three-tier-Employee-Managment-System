using EmployeeCrud.BLL.ModelVm.Department;

namespace EmployeeCrud.BLL.Service.Abstraction
{
    public interface IDepartmentService
    {
        Response<List<GetDepartmntVm>> GetActiveDepartment();
        Response<List<GetDepartmntVm>> GetInActiveDepartment();
        Response<GetDepartmntVm> GetDepartmentById(int Id);
        Response<CreateDepartmentVm> Create(CreateDepartmentVm model);
        Response<GetDepartmntVm> Update(GetDepartmntVm model);
        Response<GetDepartmntVm> Delete(GetDepartmntVm getDepartmntVm);
    }
}
