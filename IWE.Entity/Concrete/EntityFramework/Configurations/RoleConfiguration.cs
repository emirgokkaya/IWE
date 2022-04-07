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
    public class RoleConfiguration : AbstractValidator<Role>, IEntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.RoleName).IsRequired();
            builder.HasIndex(p => p.RoleName).IsUnique();
            builder.ToTable("Roles");
        }
    }
}
