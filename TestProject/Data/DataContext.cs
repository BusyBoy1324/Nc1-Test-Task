using Microsoft.EntityFrameworkCore;
using TestProject.Models;

namespace TestProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProgramingLanguage> ProgrammingLanguages { get; set; }
    }
}
