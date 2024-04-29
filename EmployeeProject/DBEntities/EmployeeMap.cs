using EmployeeProject.DBEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeProject.DBEntities
{
    public class EmployeeMap
    {
        public EmployeeMap(EntityTypeBuilder<Employee> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.EmployeeTagNumber).IsRequired();
            entityBuilder.Property(e => e.FirstName).IsRequired().HasMaxLength(10);
            entityBuilder.Property(e => e.LastName).HasMaxLength(10);
            entityBuilder.Property(e => e.Email);
            entityBuilder.Property(e => e.Department);
            entityBuilder.Property(e => e.Age);
            entityBuilder.Property(e => e.Designation);
        }
    }
}
