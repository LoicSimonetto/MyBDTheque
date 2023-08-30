using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.Core.Data
{
    public class DefaultContext : DbContext
    {
        #region Propriétés
        public DbSet<BandeDessinee> BandeDessinees { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<BandeDessineeAuteur> BandeDessineeAuteurs { get; set; }
        public DbSet<Serie> Series { get; set; }
        #endregion

        #region Constructeurs
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }

        protected DefaultContext()
        {
        }
        #endregion
        #region Methodes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BandeDessinee>()
                .HasOne(p => p.Serie)
                .WithMany(r => r.BandeDessinees)
                .HasForeignKey(s => s.SerieId);

            modelBuilder.Entity<Serie>()
                .HasMany(s => s.BandeDessinees);

            modelBuilder.Entity<BandeDessineeAuteur>()
                .HasKey(ab => new { ab.AuteurId, ab.BandeDessineeId });
            modelBuilder.Entity<BandeDessineeAuteur>()
                .HasOne(bc => bc.Auteur)
                .WithMany(b => b.BandeDessineeAuteurs)
                .HasForeignKey(bc => bc.AuteurId);
            modelBuilder.Entity<BandeDessineeAuteur>()
                .HasOne(bc => bc.BandeDessinee)
                .WithMany(c => c.BandeDessineeAuteurs)
                .HasForeignKey(bc => bc.BandeDessineeId);

        }
        #endregion

    }
}
