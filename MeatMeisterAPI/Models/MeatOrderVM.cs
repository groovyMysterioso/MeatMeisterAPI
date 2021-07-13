using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class MeatOrderVM
    {
        public MeatOrder MeatOrder { get; set; }
        public string Loins { get; set; }
        public string Rounds { get; set; }
        public string Shoulders { get; set; }
        public string Steaks { get; set; }
        public string Ribs { get; set; }
        public string Hocks { get; set; }
        public string Trim { get; set; }
        public string Notes { get; set; }

        public MeatOrderVM()
        {

        }

    }
}