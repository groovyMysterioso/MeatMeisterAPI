using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class MeatOrder : Animal
    {
        [Key]
        public int? MeatOrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        [Display(Name = "Rancher Name")]
        public string RancherName { get; set; }
        public string Notes { get; set; }
        public OrderTypes OrderType { get; set; }

        public enum OrderTypes
        {
            Deer,Elk,Beef,Hog,Sheep
        }
        public MeatOrder(DeerElkOrderVM deerElkOrderVM) 
        {
            MeatOrderID = deerElkOrderVM.MeatOrderID;
            OrderType = OrderTypes.Deer;

            CustomerName = deerElkOrderVM.CustomerName;
            CustomerPhoneNumber = deerElkOrderVM.CustomerPhoneNumber;
            Notes = deerElkOrderVM.Notes;
            KillDate = deerElkOrderVM.KillDate;
            Loins = deerElkOrderVM.Loins;
            Rounds = deerElkOrderVM.Rounds;
            Trim = deerElkOrderVM.Trim;
        }
        public MeatOrder(BeefOrderVM beefOrderVM)
        {
            MeatOrderID = beefOrderVM.MeatOrderID;
            OrderType = OrderTypes.Beef;
            CustomerName = beefOrderVM.CustomerName;
            CustomerPhoneNumber = beefOrderVM.CustomerPhoneNumber;
            Notes = beefOrderVM.Notes;
            Loins = beefOrderVM.Loins;
            Rounds = beefOrderVM.Rounds;
            Trim = beefOrderVM.Trim;
        }
        public MeatOrder(SheepOrderVM sheepOrderVM)
        {
            CustomerName = sheepOrderVM.CustomerName;
            CustomerPhoneNumber = sheepOrderVM.CustomerPhoneNumber;
            OrderType = OrderTypes.Sheep;

            Notes = sheepOrderVM.Notes;
            Loins = sheepOrderVM.Loins;
            Rounds = sheepOrderVM.Rounds;
            Trim = sheepOrderVM.Trim;
        }
        public MeatOrder(HogOrderVM hogOrderVM)
        {
            CustomerName = hogOrderVM.CustomerName;
            CustomerPhoneNumber = hogOrderVM.CustomerPhoneNumber;
            OrderType = OrderTypes.Hog;

            Notes = hogOrderVM.Notes;
            Loins = hogOrderVM.Loins;
            Rounds = hogOrderVM.Rounds;
            Trim = hogOrderVM.Trim;
        }

        public MeatOrder()
        {
        }

    }
}