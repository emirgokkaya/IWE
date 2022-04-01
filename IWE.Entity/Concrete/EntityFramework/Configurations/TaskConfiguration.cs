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
            
            builder.HasOne<User>(t => t.User).WithMany(u => u.Tasks).HasForeignKey(t => t.UserId);
            builder.HasOne<Project>(t => t.Project).WithMany(u => u.Tasks).HasForeignKey(t => t.ProjectId);
            
            builder.ToTable("Tasks");
        }
    }
}
