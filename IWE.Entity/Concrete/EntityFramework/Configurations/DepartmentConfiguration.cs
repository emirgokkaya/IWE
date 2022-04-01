using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.Entity.Concrete.EntityFramework.Configurations
{
    public class DepartmentConfiguration : AbstractValidator<Department>, IEntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.DepartmentName).IsRequired().HasMaxLength(50);
            builder.ToTable("Departments");
        }
    }
}
