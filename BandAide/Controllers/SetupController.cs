using BandAide.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Controllers
{
    public class SetupController : Controller
    {
        private UserManager<AppUser> _userManager { get; }
        private AppDbContext _context { get; set; }
        public SetupController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context; _userManager = userManager;
        }

        public async Task<string> SeedUsers(int count)
        {
            var seeder = new Utility.Seeder(_userManager, _context);
            await seeder.SeedUsers(count);
            return $"Seeded {count} users";
        }
        public string SeedBands(int count)
        {
            var seeder = new Utility.Seeder(_userManager, _context);
            seeder.SeedBands(count);
            return $"seeded {count} bands";
        }
    }
}
