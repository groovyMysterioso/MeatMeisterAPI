using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeatMeisterAPI.Models;

namespace MeatMeisterAPI.Controllers
{
    public class BeefOrdersController : Controller
    {
        private MeatMeisterDb db = new MeatMeisterDb();

        // GET: BeefOrders
        public async Task<ActionResult> Index()
        {
            var beefOrders = db.BeefOrders.Include(b => b.MeatOrder);
            return View(await beefOrders.ToListAsync());
        }

        // GET: BeefOrders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeefOrder beefOrder = await db.BeefOrders.FindAsync(id);
            if (beefOrder == null)
            {
                return HttpNotFound();
            }
            return View(beefOrder);
        }

        // GET: BeefOrders/Create
        public ActionResult Create()
        {
            ViewBag.MeatOrderID = new SelectList(db.MeatOrders, "MeatOrderID", "CustomerName");
            return View();
        }

        // POST: BeefOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,RancherName,RancherPhoneNumber,Shoulders,Steaks,Ribs,Brisket,SirloinTips,MeatOrderID")] BeefOrder beefOrder)
        {
            if (ModelState.IsValid)
            {
                db.BeefOrders.Add(beefOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MeatOrderID = new SelectList(db.MeatOrders, "MeatOrderID", "CustomerName", beefOrder.MeatOrderID);
            return View(beefOrder);
        }

        // GET: BeefOrders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeefOrder beefOrder = await db.BeefOrders.FindAsync(id);
            if (beefOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeatOrderID = new SelectList(db.MeatOrders, "MeatOrderID", "CustomerName", beefOrder.MeatOrderID);
            return View(beefOrder);
        }

        // POST: BeefOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,RancherName,RancherPhoneNumber,Shoulders,Steaks,Ribs,Brisket,SirloinTips,MeatOrderID")] BeefOrder beefOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beefOrder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MeatOrderID = new SelectList(db.MeatOrders, "MeatOrderID", "CustomerName", beefOrder.MeatOrderID);
            return View(beefOrder);
        }

        // GET: BeefOrders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BeefOrder beefOrder = await db.BeefOrders.FindAsync(id);
            if (beefOrder == null)
            {
                return HttpNotFound();
            }
            return View(beefOrder);
        }

        // POST: BeefOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BeefOrder beefOrder = await db.BeefOrders.FindAsync(id);
            db.BeefOrders.Remove(beefOrder);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
