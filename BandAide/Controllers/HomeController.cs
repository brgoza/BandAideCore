using BandAide.Models;
using BandAide.Models.Interfaces;
using BandAide.Models.Repositories;
using BandAide.Models.ViewModels;
using BandAide.Models.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide
{
    public class HomeController : Controller
    {
        private IAppUserRepository _appUserRepo { get; }
        private IBandSearchRepository _bandSearchRepo { get; }
        private IInstrumentRepository _instrumentRepo { get; }
        public HomeController(IAppUserRepository repo, IBandSearchRepository bandSearchRepo, IInstrumentRepository instrumentRepository)
        {
            _appUserRepo = repo;
            _bandSearchRepo = bandSearchRepo;
            _instrumentRepo = instrumentRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Dashboard");
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            DashBoardViewModel vm = new DashBoardViewModel();
            vm.AppUser = _appUserRepo.GetUserByName(User.Identity.Name);
            vm.Bands = _appUserRepo.GetMemberOfBands(vm.AppUser);
            vm.InstrumentSkills = _appUserRepo.GetInstrumentSkills(vm.AppUser);

            vm.BandSearches = _bandSearchRepo.GetBandSearches(vm.AppUser);
            if (vm.AppUser.BandSearches == null) vm.AppUser.BandSearches = new List<BandSearch>();
            foreach (BandSearch search in vm.AppUser.BandSearches)
            {
                search.BandSearchResults = _bandSearchRepo.ExecuteSearch(search);
            }
            return View(vm);
        }

        [Authorize]
        public IActionResult CreateBandSearch()
        {
            CreateBandSearchViewModel vm = new CreateBandSearchViewModel();
            vm.AppUser = _appUserRepo.GetUserByName(User.Identity.Name);
            vm.AppUserId = vm.AppUser.Id;
            vm.AppUser.InstrumentSkills = _appUserRepo.GetInstrumentSkills(vm.AppUser);
            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateBandSearch(CreateBandSearchViewModel obj)
        {
            var bandSearch = new BandSearch
            {
                AppUser = obj.AppUser,
                AppUserId = obj.AppUserId,
                Instrument= obj.Instrument,
                InstrumentId = obj.InstrumentId
            };

            _bandSearchRepo.CreateBandSearch(bandSearch);
            return RedirectToAction("Dashboard", "Home", null);
        }

    }
}
