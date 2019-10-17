using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eMobile_Wandio_MVC.Controllers
{
    using Domain.ServiceInterfaces;
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
    }
}