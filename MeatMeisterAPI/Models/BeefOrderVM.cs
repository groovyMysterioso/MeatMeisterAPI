using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class BeefOrderVM :BeefOrder
    {
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string Loins { get; set; }
        public string Rounds { get; set; }
        public string Trim { get; set; }
        public string Notes { get; set; }

    }
}