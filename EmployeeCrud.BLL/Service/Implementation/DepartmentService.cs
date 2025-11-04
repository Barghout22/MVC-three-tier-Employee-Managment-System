
using AutoMapper;
using EmployeeCrud.BLL.ModelVm.Department;
using EmployeeCrud.DAL.Database;
using EmployeeCrud.DAL.Entity;
using WebApplication1.Helper;

namespace EmployeeCrud.BLL.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo department;
        private readonly IMapper mapper;

        public DepartmentService(IDepartmentRepo departmentRepo,IMapper mapper)
        {
            this.department = departmentRepo;
            this.mapper = mapper;
        }

        public Response<List<GetDepartmntVm>> GetActiveDepartment()
        {
            try {

                var result = department.GetAll( d=>d.IsDeleted== false );
                var mapp = mapper.Map<List<GetDepartmntVm>>(result);
                return new Response<List<GetDepartmntVm>>(mapp, null, false);
            }
            catch(Exception e)
            {
                return new Response<List<GetDepartmntVm>>(null,e.Message,true);
            }
        }

        public Response<List<GetDepartmntVm>> GetInActiveDepartment()
        {
            try {
                var result = department.GetAll(d => d.IsDeleted == true);
                var mapp = mapper.Map<List<GetDepartmntVm>>(result);
                return new Response<List<GetDepartmntVm>>(mapp, null, false);
            }
            catch (Exception e)
            {
                return new Response<List<GetDepartmntVm>>(null, e.Message, true);
            }
        }

        public Response<GetDepartmntVm> GetDepartmentById(int Id)
        {
            try {

                var result = department.GetDepartmentById(Id);
                var mapp = mapper.Map<GetDepartmntVm>(result);
                return new Response<GetDepartmntVm>(mapp, null, false);
            }
            catch (Exception e)
            {
                return new Response<GetDepartmntVm>(null, e.Message, true);
            
            }
        }

        public Response<CreateDepartmentVm> Create(CreateDepartmentVm model)
        {
            try
            {
                var mapp = new Department(model.Name, model.Area,"mahmoud");
                var result = department.Add(mapp);
                if (result)
                {
                    return new Response<CreateDepartmentVm>(model, null, false);
                }
                return new Response<CreateDepartmentVm>(null, "problem saving Employee infor", true);
            }
            catch (Exception e)
            {
                return new Response<CreateDepartmentVm>(null, e.Message, true);
            }
        }

        public Response<GetDepartmntVm> Update(GetDepartmntVm model)
        {
            try
            {
               
                var mapp = new Department(model.Name,model.Area,"mahmoud");
                var result = department.Edit(model.Id,mapp);
                if (result)
                {
                    return new Response<GetDepartmntVm>(model, null, false);
                }

                return new Response<GetDepartmntVm>(null, "problem saving department info", true);
            }
            catch (Exception e)
            {
                return new Response<GetDepartmntVm>(null, e.Message, true);
            }
        }
        public Response<GetDepartmntVm> Delete(GetDepartmntVm getDepartmntVm)
        {
            try
            {

            var result = department.ToggleStatus(getDepartmntVm.Id);
                if (result) {
                    return new Response<GetDepartmntVm>(getDepartmntVm, null, false);
                }
                return new Response<GetDepartmntVm>(null, "problem deleting department", true);
            }
            catch(Exception e)
            {
                return new Response<GetDepartmntVm>(null, e.Message, true);
            }
        }
    }
}
