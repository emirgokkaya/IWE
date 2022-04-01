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
    public class TicketConfiguration : AbstractValidator<Ticket>, IEntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.TicketName).IsRequired();

            builder.HasOne<User>(t => t.User).WithMany(u => u.Tickets).HasForeignKey(t => t.UserId);
            
            builder.ToTable("Tickets");
        }
    }
}
