using EmployeeCrud.BLL.ModelVm.Employee;
using EmployeeCrud.BLL.Service.Abstraction;
using EmployeeCrud.BLL.Service.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeCrud.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;
        
        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var result = employeeService.GetActiveEmployee();
            return View(result);
        }
        public IActionResult GetEmployeesById(int Id)
        {
            var result = employeeService.GetEmployeeById(Id);
            return View(result.Result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeVm createEmployeeVm)
        {
            if (ModelState.IsValid) {
                var result = employeeService.Create(createEmployeeVm);
                if (!result.HasError)
                {
                    return RedirectToAction("Index", "Employee");
                }
                ViewBag.Error = result.ErrorMessage;
            }
 
                return View(createEmployeeVm);
            
            
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var query = employeeService.GetEmployeeById(Id);
            if (query.Result != null) {
               var result = query.Result;
                var updateEmpVm = new UpdateEmployeeVm() {Id=result.Id, Name = result.Name
                    , Age = result.Age ,Salary= result.Salary,OldImage= result.Image,DeptId= result.DeptId};
                return View(updateEmpVm);
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost] 
        public IActionResult Update(UpdateEmployeeVm updateEmployeeVm)
        {
            if (ModelState.IsValid)
            {
                var result = employeeService.Update(updateEmployeeVm);
                if (!result.HasError)
                {
                    return RedirectToAction("Index", "Employee");
                }
                ViewBag.error = result.ErrorMessage;
            }
            return View(updateEmployeeVm);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var query = employeeService.GetEmployeeById(Id);
            if (query.HasError)
            {
                return RedirectToAction("Error", "Home");

            }
            return View(query.Result);
        }
        [HttpPost]

        public IActionResult Delete(GetEmployeeVm getEmployeeVm)
        {
            var operation = employeeService.Delete(getEmployeeVm);
            if (!operation.HasError)
            {
                return RedirectToAction("Index", "Employee");
            }
            ViewBag.error = operation.ErrorMessage;
            return View(getEmployeeVm);
        }
    }
}
