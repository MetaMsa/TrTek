using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<LinkLine> LinkLines { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}