using System.Reflection;
using Bilet1.Models;
using Microsoft.EntityFrameworkCore;

namespace Bilet1.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<MemberPosition> MemberPositions{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
