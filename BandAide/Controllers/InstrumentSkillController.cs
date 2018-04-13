using BandAide.Models.Interfaces;
using BandAide.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAide.Controllers
{
    public class InstrumentSkillController : Controller
    {
        private IAppUserRepository _userRepo { get; }
        private IInstrumentRepository _instrumentRepo { get; }
        private IInstrumentSkillRepository _iSkillRepo { get; }
        public InstrumentSkillController(IInstrumentRepository instrumentRepo, IInstrumentSkillRepository iSkillRepo, IAppUserRepository userRepo)
        {
            _instrumentRepo = instrumentRepo;
            _iSkillRepo = iSkillRepo;
            _userRepo = userRepo;
        }
        [HttpGet]
        public IActionResult Seed()
        {
            _instrumentRepo.SeedInstruments();
            return RedirectToAction("Index", "Home", null);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create(string returnUrl = null)
        {
            var usr = _userRepo.GetUserByName(User.Identity.Name);
            var vm = new CreateInstrumentSkillViewModel { Instruments = _instrumentRepo.GetInstruments(), AppUserId=usr.Id };
            ViewData["ReturnUrl"] = returnUrl;
            return View(vm);
        }

        [AllowAnonymous]
        [HttpPost]
        [AcceptVerbs("Get", "Post")]
        public IActionResult ValidateInstrumentSkill(int instrumentId, string appUserId)
        {
            if (!_iSkillRepo.ValidateInstrumentSkill(instrumentId, appUserId))
            {
                return Json(data: "You've already told us about that skill.");
            }
            return Json(data: true);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateInstrumentSkillViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _iSkillRepo.AddInstrumentSkill(obj);
                return RedirectToAction("Index", "Home", null);
            }
            return View(obj);
        }

  
    }
}
