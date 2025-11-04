using EmployeeCrud.DAL.Database;
using System.Linq.Expressions;

namespace EmployeeCrud.DAL.Repo.Implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly EmployeeCrudDbContext Db;    
        public DepartmentRepo(EmployeeCrudDbContext Db)
        {
            this.Db = Db;
        }

        public bool Add(Department department)
        {
            try {
                var result = Db.Departments.Add(department);
                Db.SaveChanges();
                if (result.Entity.Id>0)
                {
                    return true;
                }
                return false;
            } catch(Exception) { 
                throw; 
            }
        }

        public bool Edit(int Id,Department newDept)
        {
            try
            {
                var oldDept = Db.Departments.Where(dept => dept.Id == Id).FirstOrDefault();
                if (oldDept != null)
                {
                    var result = oldDept.Update(newDept.Name, newDept.Area);
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
        public bool ToggleStatus(int Id)
        {
            try {
                var Dept = Db.Departments.FirstOrDefault(d => d.Id == Id);
                if (Dept!=null)
                {
                    var result = Dept.ToggleStatus();
                    if (result)
                    {
                        Db.SaveChanges();
                        return true;
                    }
                } return false;
            } catch (Exception)
            {
                throw;
            }


        }
        public List<Department> GetAll(Expression<Func<Department, bool>>? Filter = null)
        {
            try
            {
                if (Filter != null)
                {
                    var result = Db.Departments.Where(Filter).ToList();
                    return result;
                }
                else
                {
                    var result = Db.Departments.ToList();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Department GetDepartmentById(int Id)
        {
            try {
                var result = Db.Departments.FirstOrDefault(d => d.Id == Id);
                return result;
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
