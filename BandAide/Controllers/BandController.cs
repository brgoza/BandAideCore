using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using BandAide.Models.Interfaces;
using BandAide.Models.Repositories;
using BandAide.Models;
using Microsoft.AspNetCore.Authorization;
using BandAide.Models.ViewModels;

namespace BandAide.Controllers
{
    public class BandController : Controller
    {
        private IAppUserRepository _userRepo { get; }
        private IBandRepository _bandRepo { get; }
        private IInstrumentRepository _instrumentRepo { get; }
        private IMemberSearchRepository _memberSearchRepo { get; }

        public BandController(IAppUserRepository userRepo, IBandRepository bandRepo,
            IInstrumentRepository instrumentRepo, IMemberSearchRepository memberSearchRepo)
        {
            _userRepo = userRepo; _bandRepo = bandRepo; _instrumentRepo = instrumentRepo; _memberSearchRepo = memberSearchRepo;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ValidateBandName(string bandName)
        {
            if (!_bandRepo.ValidateBandName(bandName))
            {
                return Json(data: "That name is already taken.");
            }
            return Json(data: true);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Band obj)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepo.GetUserByName(User.Identity.Name);
                _bandRepo.AddBand(obj, user);
                return RedirectToAction("Dashboard", "Home", null);
            }
            else return View(obj);
        }

        [Authorize]
        [HttpGet]
        public IActionResult BandDashboard(int bandId)
        {
            BandDashboardViewModel vm = new BandDashboardViewModel
            {
                Band = _bandRepo.GetById(bandId)
            };


                foreach (var search in vm.Band.MemberSearches)
                {
                    search.Results = _memberSearchRepo.ExecuteSearch(search) ;
                }
            
            
            return View(vm);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details(int bandId)
        {
            var usr = _userRepo.GetUserByName(User.Identity.Name);
            if (_userRepo.IsMember(usr.Id, bandId)) return RedirectToAction("BandDashboard", bandId);
            var vm = new BandDetailsViewModel { Band = _bandRepo.GetById(bandId) };
            return View(vm);
        }

        [Authorize]
        public IActionResult CreateMemberSearch(int bandId)
        {
            CreateMemberSearchViewModel search = new CreateMemberSearchViewModel();
            search.BandId = bandId;
            search.Instruments = _instrumentRepo.GetReaminingInstrumentsForSearch(bandId);
            return View(search);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateMemberSearch(CreateMemberSearchViewModel obj)
        {
            var search = new MemberSearch
            {
                Band = obj.Band,
                BandId = obj.BandId,
                Instrument = obj.Instrument,
                InstrumentId = obj.InstrumentId
            };
            _memberSearchRepo.CreateSearch(search);
            return RedirectToAction("BandDashboard", "Band", new { bandId = obj.BandId });

        }


        //[Authorize]
        //public IActionResult MemberSearches(Band band)
        //{
        //    MemberSearchesViewModel vm = new MemberSearchesViewModel();
        //    vm.Band = band;
        //    vm.Instruments = _instrumentRepo.GetInstruments();
        //    vm.MemberSearches = _memberSearchRepo.GetCurrentSearches(band);
        //    foreach (var mSearch in vm.MemberSearches)
        //    {
        //        vm.MemberSearchResults.Add(mSearch.Id, _memberSearchRepo.ExecuteSearch(mSearch));
        //    }
        //    return View(vm);
        //}
    }
}
