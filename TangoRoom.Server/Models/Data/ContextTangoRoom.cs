using Microsoft.EntityFrameworkCore;

namespace TangoRoom.Server.Models.Data
{
    public class ContextTangoRoom : DbContext

    {
        public ContextTangoRoom(DbContextOptions<ContextTangoRoom> options) : base(options)
        {

        }

        public virtual DbSet<Marathon> Marathons { get; set; }
        public virtual DbSet<Planning> Plannings { get; set; }
        public virtual DbSet<Leader> Leaders { get; set; }
        public virtual DbSet<Inscription> Inscriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region entités marathon,leader,follower planning et inscription
            modelBuilder.Entity<Marathon>(entity =>
            {

                entity.HasKey(e => e.IdMarathon);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(120);
                entity.Property(e => e.DateDebut).HasMaxLength(120);
                entity.Property(e => e.StatutMarathon);

            });
            modelBuilder.Entity<Leader>(entity =>
            {

                entity.HasKey(e => e.IdLeader);
                entity.Property(e => e.Name).HasMaxLength(60);
                entity.Property(e => e.Email).HasMaxLength(120);
                entity.Property(e => e.Planning);
                entity.Property(e => e.StatutPersonnel);


            });
            modelBuilder.Entity<Follower>(entity =>
            {

                entity.HasKey(e => e.IDFollower);
                entity.Property(e => e.Name).HasMaxLength(60);
                entity.Property(e => e.Email).HasMaxLength(120);
                entity.Property(e => e.Planning);
                entity.Property(e => e.StatutPersonnel);


            });

            modelBuilder.Entity<Planning>(entity =>
            {

                entity.HasKey(e => e.IdPlanning);
                entity.Property(e => e.Name).HasMaxLength(60);
                entity.Property(e => e.ListeMarathons);

            });
            modelBuilder.Entity<Inscription>(entity =>
            {

                entity.HasKey(e => new { e.IdLeader, e.IdFollower, e.IdMarathon });

            });
            #endregion
        }

    }
}






//public List<Utilisateur> ListeInscritsPotentiels { get; set; } = [];
//public required StatutMarathon StatutMarathon { get; set; }