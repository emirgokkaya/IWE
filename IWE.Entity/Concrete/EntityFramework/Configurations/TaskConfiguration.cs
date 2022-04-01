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
    public class TaskConfiguration : AbstractValidator<Task>, IEntityTypeConfiguration<Task>
    {
        public TaskConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.TaskName).IsRequired();
            builder.Property(p => p.Note).IsRequired();
            builder.ToTable("Tasks");
        }
    }
}
