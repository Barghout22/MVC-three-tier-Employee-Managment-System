
namespace EmployeeCrud.DAL.Database
{
    public class EmployeeCrudDbContext:DbContext
    {
        public EmployeeCrudDbContext(DbContextOptions<EmployeeCrudDbContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=MAHMOUD\\SQLEXPRESS;Database=NtierCrud;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true ");
        //}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
