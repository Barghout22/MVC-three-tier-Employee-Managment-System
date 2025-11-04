using EmployeeCrud.DAL.Entity;

namespace EmployeeCrud.DAL.Entity
{
    public class Department
    {
        protected Department() { }
        public Department(string name, string area,string createdBy)
        {
            Name = name;
            Area = area;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            IsDeleted = false;
        }

        
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Area { get; private set; }
        public virtual IEnumerable<Employee> Employees { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string? UpdatedBy { get; private set; }

        public bool IsDeleted { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }

        public bool Update(string name, string area, string updatedBy="Mahmoud")
        {
            if (updatedBy!=null)
            {
                Name = name;
                Area = area;
                UpdatedBy = updatedBy;
                UpdatedOn = DateTime.Now;
                return true;
            }
                return false;
        }
        public bool ToggleStatus(string DeletingUser = "Mahmoud")
        {
            if (DeletingUser != null)
            {
                IsDeleted = !IsDeleted;
                DeletedOn = DateTime.Now;
                DeletedBy = DeletingUser;
                return true;
            }
            return false;
        }

    }
}
