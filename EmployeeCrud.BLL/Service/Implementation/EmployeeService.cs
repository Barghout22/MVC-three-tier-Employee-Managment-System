
using AutoMapper;
using EmployeeCrud.BLL.ModelVm.Department;
using EmployeeCrud.BLL.ModelVm.Employee;
using EmployeeCrud.DAL.Entity;
using EmployeeCrud.DAL.Repo.Implementation;
using WebApplication1.Helper;

namespace EmployeeCrud.BLL.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepo employee;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepo employeeRepo,IMapper mapper)
        {
            this.employee = employeeRepo;
            this.mapper = mapper;
        }

        public Response<List<GetEmployeeVm>> GetActiveEmployee()
        {
            try {
                var result = employee.GetAllEmployees(emp => emp.IsDeleted == false);
                var mapp = mapper.Map<List<GetEmployeeVm>>(result);
                return new Response<List<GetEmployeeVm>>(mapp, null, false);
            }
            catch(Exception e)
            {
                return new Response<List<GetEmployeeVm>>(null,e.Message , true);
            }
        }

        public Response<List<GetEmployeeVm>> GetInActiveEmployee()
        {
            try
            {
                var result = employee.GetAllEmployees(emp => emp.IsDeleted == true);
                List<GetEmployeeVm> map = new List<GetEmployeeVm>();
                foreach (var item in result)
                {
                    map.Add(new GetEmployeeVm() { Id = item.Id, Name = item.Name, Age = item.Age, });
                }
                return new Response<List<GetEmployeeVm>>(map, null, false);
            }
            catch (Exception e)
            {
                return new Response<List<GetEmployeeVm>>(null, e.Message, true);
            }
        }
        public Response<GetEmployeeVm> GetEmployeeById(int Id)
        {
            try {
                var result = employee.GetEmployeeById(Id);
                var mapp = mapper.Map<GetEmployeeVm>(result);
                return new Response<GetEmployeeVm>(mapp, null, false);
            } catch (Exception e)
            {
                return new Response<GetEmployeeVm>(null, e.Message, true);
            }
        }

        public Response<CreateEmployeeVm> Create(CreateEmployeeVm model)
        {
            try {
                string Img;
                Img = Upload.UploadFile("Files", model.Image);
                var mapp = new Employee(model.Name, model.Age, model.Salary, Img, model.DeptId, "mahmoud");
                   var result = employee.Add(mapp);
                if (result)
                {
                    return new Response<CreateEmployeeVm>(model, null, false);
                }
                return new Response<CreateEmployeeVm>(null, "problem saving Employee infor", true);
            } 
            catch(Exception e) {
                return new Response<CreateEmployeeVm>(null, e.Message, true);
            }
        }
        public  Response<UpdateEmployeeVm> Update(UpdateEmployeeVm model)
        {
            try {
                string? Img;
                if (model.Image != null)
                {
                    Img = Upload.UploadFile("Files", model.Image);
                }
                else Img = model.OldImage;

                    var mapp = new Employee(model.Name, model.Age, model.Salary, Img, model.DeptId, "mahmoud");
                var result = employee.Edit(model.Id, mapp);
                if (result)
                {
                    return new Response<UpdateEmployeeVm>(model, null, false);
                }

                return new Response<UpdateEmployeeVm>(null, "problem saving Employee infor", true);
            }
            catch (Exception e)
            {
                return new Response<UpdateEmployeeVm>(null, e.Message, true);
            }
        }

        public Response<GetEmployeeVm> Delete(GetEmployeeVm getEmployeeVm)
        {
            try {
                var result = employee.ToggleStatus(getEmployeeVm.Id);
                if (result){ 
                    return new Response<GetEmployeeVm>(getEmployeeVm, null, false); 
                }
                return new Response<GetEmployeeVm>(null, "unable to Delete Employee", true);
            
            }
            catch (Exception e)
            {
                return new Response<GetEmployeeVm>(null, e.Message, true);
            }
        }
    }
}
