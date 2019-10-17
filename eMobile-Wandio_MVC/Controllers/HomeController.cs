using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using eMobile_Wandio_MVC.Models;

namespace eMobile_Wandio_MVC.Controllers
{
    using Domain.ServiceInterfaces;
    using Domain;
    using Models;
    public class HomeController : Controller
    {
        private IManufacturerService _manufacturerService;
        private IMobileService _mobileService;

        public HomeController(IManufacturerService manufacturerService, IMobileService mobileService)
        {
            _manufacturerService = manufacturerService;
            _mobileService = mobileService;

            #region SavingData
            if (_manufacturerService.Set().Count() == 0)
            {
                _manufacturerService.Save(new Manufacturer()
                {
                    Name = "Samsung"
                });
                _manufacturerService.Save(new Manufacturer()
                {
                    Name = "Apple"
                });
                _manufacturerService.Save(new Manufacturer()
                {
                    Name = "Huawei"
                });
                _manufacturerService.Save(new Manufacturer()
                {
                    Name = "Xiaomi"
                });
                _manufacturerService.Commit();
            }
            if (_mobileService.Set().Count() == 0)
            {
                _mobileService.Save(new Mobile()
                {
                    Name = "Samsung Galaxy s7",
                    Price = 700,
                    ImageURL = "https://image-us.samsung.com/SamsungUS/home/mobile/phones/pdp/sm-g935/gallery/SMG935_edge_102116.jpg?$product-details-jpg$",
                    ManufacturerID = _manufacturerService.Set().Single(s => s.Name == "Samsung").ID,
                    OS = "Android",
                    Processor = "Smth",
                    Memory = 16
                });
                _mobileService.Save(new Mobile()
                {
                    Name = "Xiaomi Mi 6",
                    Price = 650,
                    ImageURL = "https://drop.ndtv.com/TECH/product_database/images/419201714803PM_635_xiaomi_mi_6.jpeg?downsize=*:180&output-quality=80",
                    ManufacturerID = _manufacturerService.Set().Single(s => s.Name == "Xiaomi").ID,
                    OS = "Android",
                    Processor = "Smth",
                    Memory = 16
                });
                _mobileService.Save(new Mobile()
                {
                    Name = "iPhone 6",
                    Price = 999,
                    ImageURL = "https://drop.ndtv.com/TECH/product_database/images/910201410301AM_635_apple_iphone_6.jpeg?downsize=*:180&output-quality=80",
                    ManufacturerID = _manufacturerService.Set().Single(s => s.Name == "Apple").ID,
                    OS = "iOS",
                    Processor = "Smth",
                    Memory = 32,
                    VideoLink = "https://www.youtube.com/watch?v=61TAqY03xwk"
                });
                _mobileService.Commit();
            }
            #endregion
        }

        [HttpGet]
        public IActionResult Index()
        {
            MobileItemModel mobileItemModel = new MobileItemModel()
            {
                MobileModels = _mobileService.Set().Select(s => (MobileModel)s).ToList(),
                ManufacturerModels = _manufacturerService.Set().Select(s => (ManufacturerModel)s).ToList()
            };
            return View(mobileItemModel);
        }

        [HttpPost]
        public IActionResult Index(SearchModel searchModel)
        {
            List<MobileModel> mobileModels = _mobileService.Set().Select(s => (MobileModel)s).ToList();
            if (!string.IsNullOrWhiteSpace(searchModel.SearchText))
                mobileModels = mobileModels.Where(w => w.Name.ToLower().Contains(searchModel.SearchText.ToLower())).ToList();
            if (searchModel.maxPrice > 0)
                mobileModels = mobileModels.Where(w => w.Price >= searchModel.minPrice && w.Price <= searchModel.maxPrice).ToList();
            if (Convert.ToInt32(searchModel.ManufacturerID) > 0)
                mobileModels = mobileModels.Where(w => w.ManufacturerID == Convert.ToInt32(searchModel.ManufacturerID)).ToList();

            MobileItemModel mobileItemModel = new MobileItemModel()
            {
                MobileModels = mobileModels,
                ManufacturerModels = _manufacturerService.Set().Select(s => (ManufacturerModel)s).ToList()
            };

            return View(mobileItemModel);
        }
    }
}
