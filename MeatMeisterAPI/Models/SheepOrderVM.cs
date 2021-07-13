using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class SheepOrderVM : SheepOrder

    {
        internal string CustomerName { get; set; }
        internal string CustomerPhoneNumber { get; set; }
        internal string NameOnTag { get; set; }
        internal string Loins { get; set; }
        internal string Rounds { get; set; }
        internal string Trim { get; set; }
        internal string Notes { get; set; }

    }
}