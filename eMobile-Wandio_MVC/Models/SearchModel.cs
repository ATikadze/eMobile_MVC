using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile_Wandio_MVC.Models
{
    public class SearchModel
    {
        public string SearchText { get; set; }
        public string ManufacturerID { get; set; }
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
    }
}
