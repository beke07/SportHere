using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportHere.Dal.CsvConfiguration;
using SportHere.Dal.Entities;
using SportHere.Dal.Entities.Events;
using SportHere.Dal.Entities.Users;
using SportHere.DAL.Entities.ModelBase;

namespace SportHere.Dal
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        private IEnumerable<Settlement> SeedSettlements()
        {
            using (TextReader reader = new StreamReader("../SportHere.DAL/SeedData/Telepulesek.csv"))
            using (var csvReader = new CsvReader(reader, CsvReaderConfig.Configuration))
            {
                csvReader.Configuration.RegisterClassMap<SettlementClassMap>();
                return csvReader.GetRecords<Settlement>().ToList();
            }
        }

        private IEnumerable<Sport> SeedSports()
        {
            using (TextReader reader = new StreamReader("../SportHere.DAL/SeedData/Sportok.csv"))
            using (var csvReader = new CsvReader(reader, CsvReaderConfig.Configuration))
            {
                csvReader.Configuration.RegisterClassMap<SportClassMap>();
                return csvReader.GetRecords<Sport>().ToList();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>();
            builder.Entity<Team>();

            builder.Entity<Settlement>().HasData(SeedSettlements());
            builder.Entity<Sport>().HasData(SeedSports());

            builder.Entity<Sport>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Settlement>().HasQueryFilter(p => !p.IsDeleted);
            builder.Entity<Event>().HasQueryFilter(p => !p.IsDeleted);

            builder.Entity<ApplicationUser>()
                .HasMany(b => b.Events)
                .WithOne(b => b.CreatedBy)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Event>()
                .HasOne(b => b.CreatedBy)
                .WithMany(b => b.Events)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Partition>()
                .HasKey(bc => new { bc.UserId, bc.EventId });

            builder.Entity<Partition>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.Participatings)
                .HasForeignKey(bc => bc.UserId);

            builder.Entity<Partition>()
                .HasOne(bc => bc.Event)
                .WithMany(c => c.Participants)
                .HasForeignKey(bc => bc.EventId);

            base.OnModelCreating(builder);
        }

        public DbSet<Settlement> Settlements { get; set; }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Challenge> Challenges { get; set; }
    }
}
