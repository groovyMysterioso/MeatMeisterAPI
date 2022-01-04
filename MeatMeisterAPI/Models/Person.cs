using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int PersonTypeID { get; set; }

    }
}