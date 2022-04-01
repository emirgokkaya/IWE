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
    public class CategoryConfiguration : AbstractValidator<Category>, IEntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.CategoryName).IsRequired().HasMaxLength(100);
            builder.ToTable("Categories");
        }
    }
}
