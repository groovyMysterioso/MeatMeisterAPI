using MeatMeisterAPI.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MeatMeisterAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private MeatMeisterDb db = new MeatMeisterDb();

        public ValuesController ()
        {

        }

        /// <summary>Posts the deer elk order.</summary>
        /// <param name="deerElkOrder">The deer elk order.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [ResponseType(typeof(DeerElkOrder))]
        [Route("api/postDeer", Name = "DeerMeat")]
        public IHttpActionResult PostDeerElkOrder(DeerElkOrderVM deerElkOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
                db.Entry(deerElkOrder).State = EntityState.Modified;
                var MeatOrder = db.MeatOrders.Find(deerElkOrder.MeatOrderID);
                MeatOrder.isActive = deerElkOrder.isActive.Value;
                db.Entry(MeatOrder).State = EntityState.Modified;
                db.Entry(deerElkOrder).State = EntityState.Modified;
                deerElkOrder.ID = db.DeerElkOrders.Where(x => x.MeatOrderID == deerElkOrder.MeatOrderID).First().ID;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeerElkOrderExists(deerElkOrder.ID.Value))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            db.SaveChanges();
            var newUrl = this.Url.Link("Default", new
            {
                Controller = "Home",
                Action = "Index"
            });
            
            return CreatedAtRoute("DeerMeat", new { id = deerElkOrder.ID }, deerElkOrder);
        }
        private bool DeerElkOrderExists(int id)
        {
            return db.DeerElkOrders.Count(e => e.ID == id) > 0;
        }
        [ResponseType(typeof(DeerElkOrder))]
        [Route("api/postElk", Name = "ElkMeat")]
        public IHttpActionResult PostElkOrder(DeerElkOrderVM deerElkOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (deerElkOrder.MeatOrder.MeatOrderID == null)
            {

                var MeatOrder = db.MeatOrders.Add(new MeatOrder(deerElkOrder));
            db.SaveChanges();
            var orderID = MeatOrder.MeatOrderID;
            deerElkOrder.MeatOrder.MeatOrderID = orderID;
            db.DeerElkOrders.Add(deerElkOrder);
            }
            else
            {
                var editingRecord = db.DeerElkOrders.Where(x => x.MeatOrder.MeatOrderID == deerElkOrder.MeatOrder.MeatOrderID).FirstOrDefault();
                editingRecord = deerElkOrder;
            }
            db.SaveChanges();

            return CreatedAtRoute("ElkMeat", new { id = deerElkOrder.ID }, deerElkOrder);
        }
        [Route("api/ActiveMeatOrders",Name = "ActiveMeatOrders")]
        [HttpGet]
        public IHttpActionResult ActiveMeatOrders()
        {
            return CreatedAtRoute("MeatOrders", null,new {data= db.MeatOrders.Where(_=> _.isActive).ToList() });
        }

        [Route("api/MeatOrders", Name = "MeatOrders")]
        [HttpGet]
        public IHttpActionResult AllMeatOrders()
        {
            return CreatedAtRoute("MeatOrders", null, new { data = db.MeatOrders.OrderBy(_ => _.isActive).ToList() });
        }

        [Route("api/getMeatOrder/{MeatOrderID}", Name = "getMeatOrders")]
        [HttpGet]
        public IHttpActionResult getMeatOrder(int MeatOrderID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var thisMeatOrder = db.MeatOrders.Where(x => x.MeatOrderID.Value == MeatOrderID).FirstOrDefault();

            switch (thisMeatOrder.OrderType)
            {
                case MeatOrder.OrderTypes.Deer:
                case MeatOrder.OrderTypes.Elk:
                    var deerElk = db.DeerElkOrders.Where(x => x.MeatOrderID == MeatOrderID).FirstOrDefault();
                    return CreatedAtRoute("getMeatOrders", null, new { data = deerElk });

                case MeatOrder.OrderTypes.Hog:
                    var hog = db.HogOrders.Where(x => x.MeatOrderID == MeatOrderID).FirstOrDefault();
                    return CreatedAtRoute("getMeatOrders", null, new { data = hog });

                case MeatOrder.OrderTypes.Beef:
                    var beef = db.BeefOrders.Where(x => x.MeatOrderID == MeatOrderID).FirstOrDefault();
                    return CreatedAtRoute("getMeatOrders", null, new { data = beef });
                case MeatOrder.OrderTypes.Sheep:
                    var sheep = db.SheepOrders.Where(x => x.MeatOrderID == MeatOrderID).FirstOrDefault();
                    return CreatedAtRoute("getMeatOrders", null, new { data = sheep });

            }
                return BadRequest(ModelState);

        }
        [ResponseType(typeof(BeefOrder))]
        [Route("api/postBeef", Name = "CowMeat")]
        public IHttpActionResult PostBeefOrder(BeefOrderVM beefOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
        editingRecord = beefOrder;
            }
            db.SaveChanges();

            return CreatedAtRoute("CowMeat", new { id = beefOrder.ID }, beefOrder);
        }
        [ResponseType(typeof(BeefOrder))]
        [Route("api/postPig", Name = "HogMeat")]
        public IHttpActionResult PostHogOrder(HogOrderVM hogOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
                editingRecord = hogOrder;
            }
                db.SaveChanges();

            return CreatedAtRoute("HogMeat", new { id = hogOrder.ID }, hogOrder);
        }
        [ResponseType(typeof(SheepOrder))]
        [Route("api/postSheep", Name = "SheepMeat")]
        public IHttpActionResult PostSheepOrder(SheepOrderVM sheepOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
                editingRecord = sheepOrder;
            }
                db.SaveChanges();

            return CreatedAtRoute("SheepMeat", new { id = sheepOrder.ID }, sheepOrder);
        }
        [HttpGet]
        [Route("api/deleteMeatOrder/{MeatOrderID}", Name = "DeleteOrder")]
        public IHttpActionResult PostDeleteOrder(int MeatOrderID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var thisMeatOrder = db.MeatOrders.Where(x=>x.MeatOrderID.Value == MeatOrderID).FirstOrDefault();
            
            switch(thisMeatOrder.OrderType)
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

            return CreatedAtRoute("DeleteOrder", new { id = thisMeatOrder.MeatOrderID }, thisMeatOrder);
        }
    }
}
