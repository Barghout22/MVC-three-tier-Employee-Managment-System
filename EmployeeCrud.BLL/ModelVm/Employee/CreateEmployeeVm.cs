

using Microsoft.AspNetCore.Http;

namespace EmployeeCrud.BLL.ModelVm.Employee
{
    public class CreateEmployeeVm
    {
       public string Name { get; set; }
            public int Age { get; set; }
            public double Salary { get; set; }
        public IFormFile Image { get; set; }
        public int DeptId { get; set; }
    }
}
