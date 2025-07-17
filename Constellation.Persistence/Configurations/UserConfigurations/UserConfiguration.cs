using Constellation.Core.Enums.Users;
using Constellation.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Constellation.Persistence.Configurations.UserConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Age).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(12);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.Role).IsRequired().HasDefaultValue(UserRole.DefaultUser);
            builder.Property(p => p.TelegramId).IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.Avatar).IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.UpdatedAt).IsRequired();

            builder.HasMany(u => u.MasterClasses)
                .WithMany(m => m.RegisteredUsers)
                .UsingEntity(j => j.ToTable("UserMasterClasses"));
        }
    }
}
