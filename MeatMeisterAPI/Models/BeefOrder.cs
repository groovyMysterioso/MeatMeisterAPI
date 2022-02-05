using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class BeefOrder 
    {
        [Key]
        public int? ID { get; set; }
        public string RancherName { get; set; }
        public string RancherPhoneNumber { get; set; }
        public string Shoulders { get; set; }
        public string Steaks { get; set; }
        public string Ribs { get; set; }
        public string Brisket { get; set; }
        public string SirloinTips { get; set; }
        public int? MeatOrderID { get; set; }
        public virtual MeatOrder MeatOrder { get; set; }
        public bool? isActive { get; set; }


    }
}