using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class SheepOrder 
    {
        [Key]
        public int? ID { get; set; }

        [Required]
        [Display(Name = "Rancher Number")]
        [DataType(DataType.PhoneNumber)]
        public string RancherPhoneNumber { get; set; }
        public string Shoulders { get; set; }
        public string Ribs { get; set; }
        public string Shanks { get; set; }
        public int? MeatOrderID { get; set; }
        public virtual MeatOrder MeatOrder { get; set; }


    }
}