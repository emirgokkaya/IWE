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
    public class ProjectConfiguration : AbstractValidator<Project>, IEntityTypeConfiguration<Project>
    {
        public ProjectConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.ProjectName).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.ToTable("Projects");
        }
    }
}
