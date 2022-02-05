using MeatMeisterAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatMeisterAPI.Controllers
{
    public class HomeController : Controller
    {
        private MeatMeisterDb db = new MeatMeisterDb();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return Redirect("home.htm");
        }
        [HttpPost]
        public ActionResult Index(string value)
        {
            ViewBag.Title = "Success!";

            return View();
        }
        /// <summary>Posts the deer elk order.</summary>
        /// <param name="deerElkOrder">The deer elk order.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [Route("PostDeer", Name = "DeerMeat")]
        public ActionResult PostDeer(DeerElkOrderVM deerElkOrder)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            if (deerElkOrder.MeatOrderID == null)
            {

                var MeatOrder = db.MeatOrders.Add(new MeatOrder(deerElkOrder));
                db.SaveChanges();
                var orderID = MeatOrder.MeatOrderID;
                deerElkOrder.MeatOrderID = orderID;
                db.DeerElkOrders.Add(deerElkOrder);
            }
            else
            {
                var MeatOrder = db.MeatOrders.Find(deerElkOrder.MeatOrderID);
                MeatOrder.isActive = deerElkOrder.isActive.Value;
                deerElkOrder.ID = db.DeerElkOrders.Where(x => x.MeatOrderID == deerElkOrder.MeatOrderID).First().ID;
                db.Entry(MeatOrder).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeerElkOrderExists(deerElkOrder.ID.Value))
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            db.SaveChanges();

            return Redirect("/home.htm");

        }
        [Route("PostBeef", Name = "CowMeat")]
        public ActionResult PostBeef(BeefOrderVM beefOrder)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            if (beefOrder.MeatOrderID == null)
            {
                var thisMeatOrder = db.MeatOrders.Add(new MeatOrder(beefOrder));
                db.SaveChanges();
                var orderID = thisMeatOrder.MeatOrderID;
                beefOrder.MeatOrderID = orderID;
                db.BeefOrders.Add(beefOrder);
            }
            else
            {
                var editingRecord = db.BeefOrders.Where(x => x.MeatOrderID == beefOrder.MeatOrderID).FirstOrDefault();
                var meatOrder = db.MeatOrders.Find(beefOrder.MeatOrderID);

                meatOrder.isActive = beefOrder.isActive.Value;
                editingRecord = beefOrder;
            }
            db.SaveChanges();

            return Redirect("/home.htm");
        }
        [Route("PostPig", Name = "HogMeat")]
        public ActionResult PostHog(HogOrderVM hogOrder)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            if (hogOrder.MeatOrderID == null)
            {
                var MeatOrder = db.MeatOrders.Add(new MeatOrder(hogOrder));
                db.SaveChanges();
                var orderID = MeatOrder.MeatOrderID;
                hogOrder.MeatOrderID = orderID;
                db.HogOrders.Add(hogOrder);
            }
            else
            {
                var editingRecord = db.HogOrders.Where(x => x.MeatOrderID == hogOrder.MeatOrderID).FirstOrDefault();
                var meatOrder = db.MeatOrders.Find(hogOrder.MeatOrderID);
                meatOrder.isActive = hogOrder.isActive.Value;
                editingRecord = hogOrder;
            }
            db.SaveChanges();

            return Redirect("/home.htm");
        }
        [Route("PostSheep", Name = "SheepMeat")]
        public ActionResult PostSheep(SheepOrderVM sheepOrder)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            if (sheepOrder.MeatOrderID == null)
            {
                var MeatOrder = db.MeatOrders.Add(new MeatOrder(sheepOrder));
                db.SaveChanges();
                var orderID = MeatOrder.MeatOrderID;
                sheepOrder.MeatOrderID = orderID;
                db.SheepOrders.Add(sheepOrder);
            }
            else
            {
                var editingRecord = db.SheepOrders.Where(x => x.MeatOrderID == sheepOrder.MeatOrderID).FirstOrDefault();
                var meatOrder = db.MeatOrders.Find(sheepOrder.MeatOrderID);

                meatOrder.isActive = sheepOrder.isActive.Value;

                editingRecord = sheepOrder;
            }
            db.SaveChanges();

            return Redirect("/home.htm");
        }
        [HttpGet]
        [Route("deleteMeatOrder/{MeatOrderID}", Name = "DeleteOrder")]
        public ActionResult PostDeleteOrder(int MeatOrderID)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }
            var thisMeatOrder = db.MeatOrders.Where(x => x.MeatOrderID.Value == MeatOrderID).FirstOrDefault();

            switch (thisMeatOrder.OrderType)
            {
                case MeatOrder.OrderTypes.Deer:
                case MeatOrder.OrderTypes.Elk:
                    var deerElk = db.DeerElkOrders.Where(x => x.MeatOrder.MeatOrderID == MeatOrderID).FirstOrDefault();
                    db.DeerElkOrders.Remove(deerElk);
                    break;
                case MeatOrder.OrderTypes.Hog:
                    var hog = db.HogOrders.Where(x => x.MeatOrderID == MeatOrderID).FirstOrDefault();
                    db.HogOrders.Remove(hog);
                    break;
                case MeatOrder.OrderTypes.Beef:
                    var beef = db.BeefOrders.Where(x => x.MeatOrderID == MeatOrderID).FirstOrDefault();
                    db.BeefOrders.Remove(beef);
                    break;
                case MeatOrder.OrderTypes.Sheep:
                    var sheep = db.SheepOrders.Where(x => x.MeatOrderID == MeatOrderID).FirstOrDefault();
                    db.SheepOrders.Remove(sheep);
                    break;

            }
            db.MeatOrders.Remove(thisMeatOrder);
            db.SaveChanges();

            return Redirect("/home.htm");
        }
        private bool DeerElkOrderExists(int id)
        {
            return db.DeerElkOrders.Count(e => e.ID == id) > 0;
        }
    }
}
