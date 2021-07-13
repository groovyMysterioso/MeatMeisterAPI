using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MeatMeisterAPI.Models;

namespace MeatMeisterAPI.Controllers
{
    public class DeerElkOrdersController : ApiController
    {
        private MeatMeisterDb db = new MeatMeisterDb();

        // GET: api/DeerElkOrders
        /// <summary>Gets the deer elk orders.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IQueryable<DeerElkOrder> GetDeerElkOrders()
        {
            return db.DeerElkOrders;
        }

        // GET: api/DeerElkOrders/5
        /// <summary>Gets the deer elk order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [ResponseType(typeof(DeerElkOrder))]
        public IHttpActionResult GetDeerElkOrder(int id)
        {
            DeerElkOrder deerElkOrder = db.DeerElkOrders.Find(id);
            if (deerElkOrder == null)
            {
                return NotFound();
            }

            return Ok(deerElkOrder);
        }

        // PUT: api/DeerElkOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeerElkOrder(int id, DeerElkOrder deerElkOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deerElkOrder.ID)
            {
                return BadRequest();
            }

            db.Entry(deerElkOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeerElkOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // DELETE: api/DeerElkOrders/5
        /// <summary>Deletes the deer elk order.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [ResponseType(typeof(DeerElkOrder))]
        public IHttpActionResult DeleteDeerElkOrder(int id)
        {
            DeerElkOrder deerElkOrder = db.DeerElkOrders.Find(id);
            if (deerElkOrder == null)
            {
                return NotFound();
            }

            db.DeerElkOrders.Remove(deerElkOrder);
            db.SaveChanges();

            return Ok(deerElkOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeerElkOrderExists(int id)
        {
            return db.DeerElkOrders.Count(e => e.ID == id) > 0;
        }
    }
}