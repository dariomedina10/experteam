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
    public class guiasController : Controller
    {
        private encomiendasEntities db = new encomiendasEntities();

        // GET: guias
        public ActionResult Index()
        {
            return View(db.guia.ToList());
        }

        // GET: guias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guia guia = db.guia.Find(id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            return View(guia);
        }

        // GET: guias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: guias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdGuia,NumeroGuía,FechaEnvio,PaisOrigen,NombreRemitente,DireccionRemitente,TelefonoRemitente,EmailRemitente,PaisDestino,NombreDestinatario,DireccionDestinatario,TelefonoDestinatario,EmailDestinatario,Total")] guia guia)
        {
            if (ModelState.IsValid)
            {
                db.guia.Add(guia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guia);
        }

        // GET: guias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guia guia = db.guia.Find(id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            return View(guia);
        }

        // POST: guias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdGuia,NumeroGuía,FechaEnvio,PaisOrigen,NombreRemitente,DireccionRemitente,TelefonoRemitente,EmailRemitente,PaisDestino,NombreDestinatario,DireccionDestinatario,TelefonoDestinatario,EmailDestinatario,Total")] guia guia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guia);
        }

        // GET: guias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            guia guia = db.guia.Find(id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            return View(guia);
        }

        // POST: guias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            guia guia = db.guia.Find(id);
            db.guia.Remove(guia);
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
