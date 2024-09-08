using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.userName).IsRequired();
            builder.Property(x => x.userSurname).IsRequired();
            builder.Property(x => x.userEmail).IsRequired();
            builder.Property(x => x.userPassword).IsRequired();
            builder.Property(x => x.userBirthDate).IsRequired();
        }
    }
}