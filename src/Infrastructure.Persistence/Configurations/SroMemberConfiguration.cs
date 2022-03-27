using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SroParser.Domain.Entities;

namespace Infrastructure.Persistence.Configurations;

public class SroMemberConfiguration : IEntityTypeConfiguration<SroMember>
{
    public void Configure(EntityTypeBuilder<SroMember> builder)
    {
        builder.HasKey(s => s.Id)
            .HasName("id");

        builder.Property(s => s.FullName)
            .HasColumnName("full_name");
        builder.Property(s => s.ShortName)
            .HasColumnName("short_name");
        builder.Property(s => s.IdentificationNumber)
            .HasColumnName("identification_number");

        builder.ToTable("sro_member");
    }
}