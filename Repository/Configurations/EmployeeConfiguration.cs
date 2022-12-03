using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Configurations;

public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee", "employee");
        builder.Property(x => x.Address).HasMaxLength(255);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Phone).HasMaxLength(20);
    }
}