using EmployeeProject.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.DBEntities
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new EmployeeMap(modelBuilder.Entity<Employee>());
        }
    }
}
