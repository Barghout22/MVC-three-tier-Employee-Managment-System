namespace EmployeeCrud.DAL.Entity
{
    public class Employee
    {
        protected Employee() { }
        public Employee(string name, int age, double salary, string image, int deptId, string createdBy)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Image = image;
            DeptId = deptId;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Salary { get; private set; }
        public string Image { get; private set; }
        
        [ForeignKey("Department")]
        public int? DeptId { get; private set; }
        public virtual Department? Department { get; private set; }

        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public string? UpdatedBy { get; private set; }

        public bool IsDeleted { get; private set; } 
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }

        public bool Update(string name, int age,double salary,string image,int deptId, string updatedby="Mahmoud")
        {
            if (updatedby!=null)
            {
                Name = name;
                Salary = salary;
                Age = age;
                Image = image;
                DeptId = deptId;
                UpdatedBy = updatedby;
                UpdatedOn = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool ToggleStatus(string DeletingUser="Mahmoud")
        {
            if (DeletingUser != null) {
                IsDeleted = !IsDeleted;
                DeletedOn = DateTime.Now;
                DeletedBy = DeletingUser;
                return true;
            }
            return false;
        }
    }
}
