using BandAide.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<BandMember> BandsMembers { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<InstrumentSkill> InstrumentSkills { get; set; }
        public DbSet<BandSearch> BandSearches { get; set; }
        public DbSet<MemberSearch> MemberSearches { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(u => u.BandsMembers);
            builder.Entity<Band>()
                .HasMany(u => u.BandsMembers);

            builder.Entity<AppUser>()
                .HasMany(u => u.BandSearches);
            builder.Entity<Band>()
                .HasMany(b => b.MemberSearches);

            builder.Entity<BandMember>().HasKey("BandId", "AppUserId");

            builder.Entity<Band>().HasAlternateKey(b => b.Name);

            builder.Entity<InstrumentSkill>().HasAlternateKey("InstrumentId", "AppUserId");
            builder.Entity<InstrumentSkill>().HasOne(iSkill => iSkill.User).WithMany(u => u.InstrumentSkills);

            builder.Entity<MemberSearch>().HasAlternateKey("BandId", "InstrumentId");
            
            //builder.Entity<MemberSearch>().HasOne(ms => ms.Band).WithMany(b => b.MemberSearches);
            builder.Entity<BandSearch>().HasAlternateKey("AppUserId", "InstrumentId");
            //builder.Entity<BandSearch>().HasOne(bs => bs.AppUser).WithMany(u => u.BandSearches);

            builder.Entity<Instrument>().HasAlternateKey(i => i.Name);

        }
    }
}
