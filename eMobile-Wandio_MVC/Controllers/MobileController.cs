using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eMobile_Wandio_MVC.Controllers
{
    using Domain.ServiceInterfaces;
    using Domain;
    using Models;
    public class MobileController : Controller
    {
        private IMobileService _mobileService;
        private IManufacturerService _manufacturerService;

        public MobileController(IMobileService mobileService, IManufacturerService manufacturerService)
        {
            _mobileService = mobileService;
            _manufacturerService = manufacturerService;
        }

        public IActionResult Details(int id)
        {
            return View((MobileModel)_mobileService.Set().Single(s => s.ID == id));
        }

        [HttpGet]
        public IActionResult New()
        {
            NewMobileModel newMobileModel = new NewMobileModel()
            {
                ManufacturerModels = _manufacturerService.Set().Select(s => (ManufacturerModel)s).ToList()
            };
            return View(newMobileModel);
        }

        [HttpPost]
        public IActionResult New(MobileModel mobileModel)
        {
            _mobileService.Save((Mobile)mobileModel);
            _mobileService.Commit();
            return RedirectToAction("Index", "Home");
        }
    }
}