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
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn();
            builder.Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired().HasMaxLength(30);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();

            builder.ToTable("Users");
        }
    }
}
