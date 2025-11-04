using EmployeeCrud.BLL.ModelVm.Department;
using EmployeeCrud.BLL.ModelVm.Employee;
using EmployeeCrud.BLL.Service.Abstraction;
using EmployeeCrud.BLL.Service.Implementation;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EmployeeCrud.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var result = departmentService.GetActiveDepartment();
            return View(result);
        }
        public IActionResult GetDepartmentsById(int Id)
        {
            var result = departmentService.GetDepartmentById(Id);
            return View(result.Result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentVm createDepartmentVm) {
            if (ModelState.IsValid)
            {
                var result = departmentService.Create(createDepartmentVm);
                if (!result.HasError)
                {
                    return RedirectToAction("Index", "Department");
                }
                ViewBag.Error = result.ErrorMessage;
            }

            return View(createDepartmentVm);

        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var query = departmentService.GetDepartmentById(Id);
            if (!query.HasError)
            {
                var result = query.Result;
            return View(result);
            }
            return RedirectToAction("Error", "Home");

        }
        [HttpPost]
        public IActionResult Update(GetDepartmntVm getDepartmntVm)  {
            
            if (ModelState.IsValid)
            {
                var result = departmentService.Update(getDepartmntVm);
                if (!result.HasError)
                {
                  return RedirectToAction("Index", "Department");
                 }
                ViewBag.error = result.ErrorMessage;
            }
               return View(getDepartmntVm);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var deletedDept = departmentService.GetDepartmentById(Id);
            if (deletedDept.HasError)
            {
                return RedirectToAction("Error", "Home");

            }
            return View(deletedDept.Result);
        }
        [HttpPost]
        public IActionResult Delete(GetDepartmntVm getDepartmntVm)
        {
            var operation = departmentService.Delete(getDepartmntVm);
            if (!operation.HasError)
            {
                return RedirectToAction("Index", "Department");
            }
            ViewBag.error = operation.ErrorMessage;
            return View(getDepartmntVm);

        }
    }
}
