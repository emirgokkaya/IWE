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
    public class UserConfiguration : AbstractValidator<User>, IEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage($"{0} alanı boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage($"Lütfen geçerli bir {0} adresi girin");
        }
        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();

            builder.HasOne<Role>(u => u.Role).WithMany(r => r.Users).HasForeignKey(u => u.RoleId);
            builder.HasOne<Department>(u => u.Department).WithMany(d => d.Users).HasForeignKey(u => u.DepartmentId);

            builder.ToTable("Users");
        }
    }
}
