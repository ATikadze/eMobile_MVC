using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile_Wandio_MVC.Models
{
    public class ManufacturerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static explicit operator ManufacturerModel(Domain.Manufacturer manufacturer)
        {
            return new ManufacturerModel()
            {
                ID = manufacturer.ID,
                Name = manufacturer.Name
            };
        }
    }
}
