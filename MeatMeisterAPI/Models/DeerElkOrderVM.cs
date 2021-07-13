using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class DeerElkOrderVM :DeerElkOrder
    {
        [Key]
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public DateTime? KillDate { get; set; }
        public string Loins { get; set; }
        public string Rounds { get; set; }
        public string Trim { get; set; }
        public string Notes { get; set; }

        public DeerElkOrderVM()
        {

        }
    }
}