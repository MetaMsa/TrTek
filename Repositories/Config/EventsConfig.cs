using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class EventsConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.FirstDate).IsRequired();
            builder.Property(p => p.LastDate).IsRequired();
            builder.Property(p => p.Image).IsRequired();
            builder.Property(p => p.AddedBy).IsRequired();
            builder.Property(p => p.AddedDate).IsRequired();
            builder.Property(p => p.isActive).IsRequired();
            builder.Property(p => p.shortDescription).IsRequired();

            builder.HasData(
                new Event()
                {
                    Id = 1,
                    Name = "Event 1",
                    FirstDate = new DateTime(2021, 1, 1),
                    LastDate = new DateTime(2021, 1, 2),
                    Image = "/images/image1.jpg",
                    AddedBy = "Admin",
                    AddedDate = new DateTime(2021, 1, 1),
                    isActive = true,
                    shortDescription = "Event 1 short description"
                }
            );
        }
    }
}