using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    // Entity Class :  It represent database table
    public class Employee
    {
        
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }


    public class UserEmpDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public UserEmpDbContext(DbContextOptions<UserEmpDbContext> options)
         : base(options)
        {

        }

    }
}