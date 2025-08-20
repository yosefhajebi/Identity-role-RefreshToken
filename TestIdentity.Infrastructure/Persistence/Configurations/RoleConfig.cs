using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestIdentity.Domain.Entities;

namespace TestIdentity.Infrastructure.Persistence.Configurations;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name).IsRequired().HasMaxLength(50);

        // builder.HasMany(r => r.UserRoles)
        //        .WithOne(ur => ur.Role)
        //        .HasForeignKey(ur => ur.RoleId);
    }
}
