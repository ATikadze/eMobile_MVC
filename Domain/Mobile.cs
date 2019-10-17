using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Mobile
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string OS { get; set; }
        [Required]
        public int Memory { get; set; }
        public string Processor { get; set; } = "[Unknown]";
        public string Size { get; set; } = "[Unknown]";
        public string Weight { get; set; } = "[Unknown]";
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public virtual int ManufacturerID { get; set; }
        [Required]
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
