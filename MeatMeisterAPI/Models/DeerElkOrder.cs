using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class DeerElkOrder
    {
        [Key]
        public int? ID { get; set; }
        
        [Required]
        [Display(Name = "Name On Tag")]
        public string NameOnTag { get; set; }
        public string Steaks { get; set; }
        public string Ribs { get; set; }
        public int? MeatOrderID { get; set; }
        public virtual MeatOrder MeatOrder { get; set; }

        public DeerElkOrder()
        { }
    }
}