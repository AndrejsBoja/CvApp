using System.Data.Entity;
using CvStorage.Core;
using CvStorage.Data.Migrations;

namespace CvStorage.Data
{
    public class CvStorageDbContext : DbContext 
    {
        public CvStorageDbContext() : base(nameOrConnectionString: "CvStorage")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CvStorageDbContext, Configuration>());
        }

        public DbSet<Cv> Cv { get; set; } 
        public DbSet<PersonInfo> PersonInfos { get; set; } 
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(ad => ad.Id);

            modelBuilder.Entity<Cv>()
                .HasOptional(cv => cv.Address)
                .WithRequired(a => a.Cv)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<PersonInfo>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Cv>()
                .HasOptional(cv => cv.PersonInfo)
                .WithRequired(p => p.Cv)
                .WillCascadeOnDelete(true);
        }
    }
}