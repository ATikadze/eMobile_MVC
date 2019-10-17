using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile_Wandio_MVC.Models
{
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
        public string Processor { get; set; }
        public int Memory { get; set; }
        public string OS { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }
        public string ImageURL { get; set; }
        public int ManufacturerID { get; set; }

        public static explicit operator MobileModel(Domain.Mobile mobile)
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
                ManufacturerID = mobile.ManufacturerID
            };
        }
    }
}
