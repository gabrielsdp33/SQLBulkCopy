namespace BulkCopyCSV.Infra.Data.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=ContextModel")
        {
        }

        public virtual DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Movies>()
                .Property(e => e.LeadStudio)
                .IsUnicode(false);

            modelBuilder.Entity<Movies>()
                .Property(e => e.AudienceScorePercentage)
                .IsUnicode(false);

            modelBuilder.Entity<Movies>()
                .Property(e => e.Profability)
                .IsUnicode(false);

            modelBuilder.Entity<Movies>()
                .Property(e => e.RottenTomatoesPercentage)
                .IsUnicode(false);

            modelBuilder.Entity<Movies>()
                .Property(e => e.WorldwideGross)
                .IsUnicode(false);

            modelBuilder.Entity<Movies>()
                .Property(e => e.Year)
                .IsUnicode(false);
        }
    }
}
