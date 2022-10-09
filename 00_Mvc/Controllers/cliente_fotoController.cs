using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _04_Data.Data;

namespace _00_Mvc.Controllers
{
    public class cliente_fotoController : Controller
    {
        private KingspicDbContext db = new KingspicDbContext();

        // GET: cliente_foto
        public ActionResult Index()
        {
            var cliente_foto = db.cliente_foto.Include(c => c.cliente).Include(c => c.foto);
            return View(cliente_foto.ToList());
        }

        // GET: cliente_foto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente_foto cliente_foto = db.cliente_foto.Find(id);
            if (cliente_foto == null)
            {
                return HttpNotFound();
            }
            return View(cliente_foto);
        }

        // GET: cliente_foto/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.cliente, "id", "login");
            ViewBag.id_foto = new SelectList(db.foto, "id", "descripcion");
            return View();
        }

        // POST: cliente_foto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_cliente,id_foto,fecha_visionado,me_gusta")] cliente_foto cliente_foto)
        {
            if (ModelState.IsValid)
            {
                db.cliente_foto.Add(cliente_foto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.cliente, "id", "login", cliente_foto.id_cliente);
            ViewBag.id_foto = new SelectList(db.foto, "id", "descripcion", cliente_foto.id_foto);
            return View(cliente_foto);
        }

        // GET: cliente_foto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente_foto cliente_foto = db.cliente_foto.Find(id);
            if (cliente_foto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "id", "login", cliente_foto.id_cliente);
            ViewBag.id_foto = new SelectList(db.foto, "id", "descripcion", cliente_foto.id_foto);
            return View(cliente_foto);
        }

        // POST: cliente_foto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_cliente,id_foto,fecha_visionado,me_gusta")] cliente_foto cliente_foto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente_foto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.cliente, "id", "login", cliente_foto.id_cliente);
            ViewBag.id_foto = new SelectList(db.foto, "id", "descripcion", cliente_foto.id_foto);
            return View(cliente_foto);
        }

        // GET: cliente_foto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente_foto cliente_foto = db.cliente_foto.Find(id);
            if (cliente_foto == null)
            {
                return HttpNotFound();
            }
            return View(cliente_foto);
        }

        // POST: cliente_foto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente_foto cliente_foto = db.cliente_foto.Find(id);
            db.cliente_foto.Remove(cliente_foto);
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
