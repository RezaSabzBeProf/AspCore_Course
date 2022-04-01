using Microsoft.EntityFrameworkCore;

namespace AspCore_Course.Models
{
    public class FarsLearnContext : DbContext
    {

        public FarsLearnContext(DbContextOptions<FarsLearnContext> options) : base(options)
        {

        }


        #region Tabels
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}

