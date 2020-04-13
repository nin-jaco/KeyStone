using Microsoft.EntityFrameworkCore;

namespace KeyStone.DegreeOfAssociationCSharp.DataModel
{

    public class EntityModel : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=KeyStone;Trusted_Connection=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Association>().HasKey(sc => new { sc.IdParty, sc.IdGrandParent });

            //modelBuilder.Entity<Association>()
            //    .HasOne<Party>(sc => sc.Party)
            //    .WithMany(s => s.Associations)
            //    .HasForeignKey(sc => sc.IdParty);


            //modelBuilder.Entity<Association>()
            //    .HasOne<GrandParent>(sc => sc.GrandParent)
            //    .WithMany(s => s.Associations)
            //    .HasForeignKey(sc => sc.IdGrandParent);
        }

        public virtual DbSet<GrandParent> GrandParents { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<Association> Associations { get; set; }
    }
}
