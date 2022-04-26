using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Experteam;

namespace Experteam.Controllers
{
    public class guia_facturaController : Controller
    {
        private encomiendasEntities db = new encomiendasEntities();

        // GET: guia_factura
        public ActionResult Index()
        {
            var guia_factura = db.guia_factura.Include(g => g.factura);
            return View(guia_factura.ToList());
        }

        // GET: guia_factura/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guia_factura guia_factura = db.guia_factura.Find(id);
            if (guia_factura == null)
            {
                return HttpNotFound();
            }
            return View(guia_factura);
        }

        // GET: guia_factura/Create
        public ActionResult Create()
        {
            ViewBag.idfactura = new SelectList(db.factura, "IdFactura", "Establecimiento");
            return View();
        }

        // POST: guia_factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_guia_factura,idguia,idpago,idfactura")] guia_factura guia_factura)
        {
            if (ModelState.IsValid)
            {
                db.guia_factura.Add(guia_factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idfactura = new SelectList(db.factura, "IdFactura", "Establecimiento", guia_factura.idfactura);
            return View(guia_factura);
        }

        // GET: guia_factura/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guia_factura guia_factura = db.guia_factura.Find(id);
            if (guia_factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idfactura = new SelectList(db.factura, "IdFactura", "Establecimiento", guia_factura.idfactura);
            return View(guia_factura);
        }

        // POST: guia_factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_guia_factura,idguia,idpago,idfactura")] guia_factura guia_factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guia_factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idfactura = new SelectList(db.factura, "IdFactura", "Establecimiento", guia_factura.idfactura);
            return View(guia_factura);
        }

        // GET: guia_factura/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guia_factura guia_factura = db.guia_factura.Find(id);
            if (guia_factura == null)
            {
                return HttpNotFound();
            }
            return View(guia_factura);
        }

        // POST: guia_factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            guia_factura guia_factura = db.guia_factura.Find(id);
            db.guia_factura.Remove(guia_factura);
            db.SaveChanges();
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
