using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class BeefOrderVM :BeefOrder
    {
        public int? MeatOrderID { get; internal set; }
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }
        [Display(Name = "Customer Phone Number")]
        public string CustomerPhoneNumber { get; set; }
        public string Loins { get; set; }
        public string Rounds { get; set; }
        public string Trim { get; set; }
        public string Notes { get; set; }

    }
}