using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class Animal
    {
        public DateTime? KillDate { get; set; }
        public string Loins { get; set; }
        public string Rounds { get; set; }
        public string Trim { get; set; }
    }
}