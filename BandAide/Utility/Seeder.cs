using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using BandAide.Models;
using BandAide.Models.Interfaces;

namespace BandAide.Utility
{
    public class Seeder
    {
        private const string mockarooKey = "e8491c40";
        private const string mockarooSeedUsersSchema = "BandAideUser";
        private const string mockarooSeedBandsSchema = "BandNames";

        private AppDbContext _context { get; }
        private UserManager<AppUser> _userManager { get; }
        public Seeder(UserManager<AppUser> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }



        public class MockarooSeedUsersResponse
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Address1 { get; set; }
            public string City { get; set; }
            public string StateAbbr { get; set; }
            public string Zip { get; set; }
        }

        public async Task<IdentityResult> SeedUsers(int count)
        {
            RestClient client = new RestClient("https://api.mockaroo.com/api/generate.json");
            RestRequest request = new RestRequest();
            request.AddParameter("key", mockarooKey);
            request.AddParameter("schema", mockarooSeedUsersSchema);
            request.AddParameter("count", count);
            var response = client.Execute(request);
            var obj = JsonConvert.DeserializeObject<List<MockarooSeedUsersResponse>>(response.Content);

            foreach (var result in obj)
            {
                var usr = new AppUser()
                {
                    UserName = result.Email,
                    Email = result.Email,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Address1 = result.Address1,
                    Address2 = "",
                    City = result.City,
                    StateAbbr = result.StateAbbr,
                    Zip = result.Zip
                };
                var a = await _userManager.CreateAsync(usr, "Password0!");
                _context.SaveChanges();
            }
            return null;
        }
        public AppUser GetRandomUser(int seed)
        {
            var rnd = new Random(seed);
            var index = rnd.Next(_context.Users.Count());
            return _context.Users.ToList()[index];
        }

        public bool SeedBands(int count)
        {
            RestClient client = new RestClient("https://api.mockaroo.com/api/generate.csv");
            RestRequest request = new RestRequest();
            request.AddParameter("key", mockarooKey);
            request.AddParameter("schema", mockarooSeedBandsSchema);
            request.AddParameter("count", count);
            var response = client.Execute(request);
            var bandNames = response.Content.Split("\n");

            foreach (string item in bandNames)
            {
                var band = new Band
                {
                    Name = item,
                    BandsMembers = new List<BandMember>()
                };
                _context.Bands.Add(band);
                _context.SaveChanges();
                var randomUser = GetRandomUser(band.Id);
                band.BandsMembers.Add(new BandMember { AppUser = randomUser, AppUserId = randomUser.Id, IsAdmin = true });
                _context.SaveChanges();
            }
            return true;
        }
    }
}
