using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class HogOrder
    {
        [Key]
        public int? ID { get; set; }
        public string RancherName { get; set; }
        public string RancherPhoneNumber { get; set; }
        public string Shoulders { get; set; }
        public string Hocks { get; set; }
        public string Ribs { get; set; }
        public int? MeatOrderID { get; set; }
        public virtual MeatOrder MeatOrder {get;set;}

    }
}