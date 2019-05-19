using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportHere.Dal.Entities;
using SportHere.Dal.Entities.Users;

namespace SportHere.Dal
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        private IEnumerable<Settlement> SeedSettlements()
        {
            using (TextReader reader = new StreamReader("../SportHere.DAL/SeedData/Telepulesek.csv"))
            using (var csvReader = new CsvReader(reader))
            {
                return csvReader.GetRecords<Settlement>().ToList();
            }
        }

        private IEnumerable<Sport> SeedSports()
        {
            using (TextReader reader = new StreamReader("../SportHere.DAL/SeedData/Sportok.csv"))
            using (var csvReader = new CsvReader(reader))
            {
                return csvReader.GetRecords<Sport>().ToList();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>();
            builder.Entity<Team>();

            builder.Entity<Settlement>().HasData(SeedSettlements());
            builder.Entity<Sport>().HasData(SeedSports());

            base.OnModelCreating(builder);
        }

        public DbSet<Settlement> Settlements { get; set; }

        public DbSet<Sport> Sports { get; set; }
    }
}
