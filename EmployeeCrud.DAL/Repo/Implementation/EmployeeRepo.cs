
using System.Linq.Expressions;

namespace EmployeeCrud.DAL.Repo.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeCrudDbContext Db;
        public EmployeeRepo(EmployeeCrudDbContext Db) {
            this.Db = Db;
        }
        public bool Add(Employee employee)
        {
            try {
                var result = Db.Employees.Add(employee);
                Db.SaveChanges();
                if (result.Entity.Id > 0) return true;
                else return false;
            } catch(Exception)
            {
                throw;
            }
        }

        public bool Edit(int Id,Employee newEmp)
        {
            try {
                var oldEmp = Db.Employees.Where(emp => emp.Id ==Id).FirstOrDefault();
                if (oldEmp != null) {
                    var result = oldEmp.Update(newEmp.Name, newEmp.Age, newEmp.Salary,newEmp.Image, (int)newEmp.DeptId);
                    if (result)
                    {
                        Db.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }

        }



        public List<Employee> GetAllEmployees(Expression<Func<Employee, bool>>? Filter = null)
        {
            try
            {
                if (Filter != null)
                {
                    var result = Db.Employees.Where(Filter).ToList();
                    return result;
                }
                else
                {
                    var result = Db.Employees.ToList();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee GetEmployeeById(int Id)
        {
            try {

                var result = Db.Employees.FirstOrDefault(e => e.Id == Id);
                return result;
            }
            catch(Exception) { 
                throw; 
            }
        }

        public bool ToggleStatus(int Id)
        {
            try {
                var emp = Db.Employees.Where(emp => emp.Id == Id).FirstOrDefault();
                if (emp!=null) {
                    var result=emp.ToggleStatus();
                    if (result)
                    {
                        Db.SaveChanges();
                        return true;
                    }
                }return false;
            }
            catch (Exception){
                throw;
            }
        }
    }
}
