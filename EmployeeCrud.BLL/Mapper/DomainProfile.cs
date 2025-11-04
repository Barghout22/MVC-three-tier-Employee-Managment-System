using AutoMapper;
using EmployeeCrud.BLL.ModelVm.Department;
using EmployeeCrud.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCrud.BLL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, GetEmployeeVm>().ReverseMap();
            CreateMap<CreateEmployeeVm, Employee>();
            CreateMap<Department, GetDepartmntVm>().ReverseMap();
        }
    }
}
