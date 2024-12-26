using Microsoft.EntityFrameworkCore;

namespace TangoRoom.Server.Models.Data
{
    public class ContextTangoRoom : DbContext

    {
        public ContextTangoRoom(DbContextOptions<ContextTangoRoom> options) : base(options)
        {

        }

        public virtual DbSet<Marathon> Marathons { get; set; }
        public virtual DbSet<Leader> Leaders { get; set; }
        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Inscription> Inscriptions { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region entités marathon,leader,follower planning et inscription

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasKey(e => e.IdUtilisateur);
                entity.Property(e => e.Name).HasMaxLength(60);
                entity.Property(e => e.Email).HasMaxLength(120);
                entity.Property(e => e.StatutPersonnel);
                entity.Property(e => e.IdRole);
                entity.Property(e => e.Link).HasMaxLength(120);
                entity.Property(e => e.ValideInscription);
                entity.HasOne<Role>().WithMany().HasForeignKey(d => d.IdRole).OnDelete(DeleteBehavior.NoAction);


            });
            modelBuilder.Entity<Marathon>(entity =>
            {
                entity.HasKey(e => e.IdMarathon);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(120);
                entity.Property(e => e.StatutMarathon).HasDefaultValue(StatutMarathon.disponible);
                entity.HasMany(e => e.ListeInscritsPotentiels).WithMany(m => m.Planning)
                .UsingEntity(l => l.HasOne(typeof(Utilisateur)).WithMany().HasForeignKey("IdUtilisateur").OnDelete(DeleteBehavior.NoAction),
                             r => r.HasOne(typeof(Marathon)).WithMany().HasForeignKey("IdMarathon").OnDelete(DeleteBehavior.NoAction)).ToTable("PlanningAnnuel");
                entity.ToTable(t => t.HasCheckConstraint("CK_MarathonStatus", "StatutMarathon IN (0, 1)"));
                entity.ToTable(t => t.HasCheckConstraint("CK_MarathonValidity", "(DateDebut >= GETDATE())"));
                entity.ToTable(t => t.HasCheckConstraint("CK_MarathonEndRegister", "( DateFinInscription<=DATEADD(d,-15,DateDebut))"));

            });




            modelBuilder.Entity<Leader>(entity =>
            {

            });
            modelBuilder.Entity<Follower>(entity =>
            {
                entity.Property(e => e.TextInvitation);

            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Inscription>(entity =>
            {

                entity.HasKey(e => new { e.IdLeader, e.IdFollower, e.IdMarathon });
                entity.HasOne<Leader>().WithMany().HasForeignKey(d => d.IdLeader).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Follower>().WithMany().HasForeignKey(d => d.IdFollower).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne<Marathon>().WithMany().HasForeignKey(d => d.IdMarathon).OnDelete(DeleteBehavior.NoAction);

            });

            #endregion
        }

    }
}






