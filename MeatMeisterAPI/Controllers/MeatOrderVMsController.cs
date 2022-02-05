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
    public class MeatOrderVMsController : Controller
    {
        private MeatMeisterDb db = new MeatMeisterDb();

        // GET: MeatOrderVMs
        public async Task<ActionResult> Index()
        {
            return View(await db.MeatOrderVMs.ToListAsync());
        }

        // GET: MeatOrderVMs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeatOrderVM meatOrderVM = await db.MeatOrderVMs.FindAsync(id);
            if (meatOrderVM == null)
            {
                return HttpNotFound();
            }
            return View(meatOrderVM);
        }

        // GET: MeatOrderVMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeatOrderVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Loins,Rounds,Shoulders,Steaks,Ribs,Hocks,Trim,Notes")] MeatOrderVM meatOrderVM)
        {
            if (ModelState.IsValid)
            {
                db.MeatOrderVMs.Add(meatOrderVM);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(meatOrderVM);
        }

        // GET: MeatOrderVMs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeatOrderVM meatOrderVM = await db.MeatOrderVMs.FindAsync(id);
            if (meatOrderVM == null)
            {
                return HttpNotFound();
            }
            return View(meatOrderVM);
        }

        // POST: MeatOrderVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Loins,Rounds,Shoulders,Steaks,Ribs,Hocks,Trim,Notes")] MeatOrderVM meatOrderVM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meatOrderVM).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(meatOrderVM);
        }

        // GET: MeatOrderVMs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeatOrderVM meatOrderVM = await db.MeatOrderVMs.FindAsync(id);
            if (meatOrderVM == null)
            {
                return HttpNotFound();
            }
            return View(meatOrderVM);
        }

        // POST: MeatOrderVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MeatOrderVM meatOrderVM = await db.MeatOrderVMs.FindAsync(id);
            db.MeatOrderVMs.Remove(meatOrderVM);
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
