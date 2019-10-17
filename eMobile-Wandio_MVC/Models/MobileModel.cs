using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile_Wandio_MVC.Models
{
    using Domain;
    public class NewMobileModel
    {
        public MobileModel MobileModel { get; set; }
        public List<ManufacturerModel> ManufacturerModels { get; set; }
    }

    public class MobileItemModel
    {
        public SearchModel SearchModel { get; set; }
        public ManufacturerModel ManufacturerModel { get; set; }
        public List<MobileModel> MobileModels { get; set; }
        public List<ManufacturerModel> ManufacturerModels { get; set; }
    }

    public class MobileModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Processor { get; set; } = "[Unknown]";
        public int Memory { get; set; }
        public string OS { get; set; }
        public float Price { get; set; }
        public float Size { get; set; }
        public float Weight { get; set; }
        public string ImageURL { get; set; }
        public string VideoLink { get; set; }
        public int ManufacturerID { get; set; }

        public static explicit operator MobileModel(Mobile mobile)
        {
            return new MobileModel()
            {
                ID = mobile.ID,
                Name = mobile.Name,
                ImageURL = mobile.ImageURL,
                Memory = mobile.Memory,
                OS = mobile.OS,
                Price = mobile.Price,
                Processor = mobile.Processor,
                Size = mobile.Size,
                Weight = mobile.Weight,
                VideoLink = mobile.VideoLink,
                ManufacturerID = mobile.ManufacturerID
            };
        }

        public static explicit operator Mobile(MobileModel mobileModel)
        {
            return new Mobile()
            {
                ID = mobileModel.ID,
                Name = mobileModel.Name,
                ImageURL = mobileModel.ImageURL,
                Memory = mobileModel.Memory,
                OS = mobileModel.OS,
                Price = mobileModel.Price,
                Processor = mobileModel.Processor,
                Size = mobileModel.Size,
                Weight = mobileModel.Weight,
                VideoLink = mobileModel.VideoLink,
                ManufacturerID = mobileModel.ManufacturerID
            };
        }
    }
}
