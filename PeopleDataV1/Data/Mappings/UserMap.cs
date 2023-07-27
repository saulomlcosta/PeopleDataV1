using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleDataV1.Entities;

namespace PeopleDataV1.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                    .IsRequired();

            builder
                .HasIndex(x => x.UserName, "IX_User_UserName")
                .IsUnique();
        }
    }
}
