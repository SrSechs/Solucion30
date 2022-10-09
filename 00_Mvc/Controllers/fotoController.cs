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
    public class fotoController : Controller
    {
        private KingspicDbContext db = new KingspicDbContext();

        // GET: foto
        public ActionResult Index()
        {
            var foto = db.foto.Include(f => f.categoria).Include(f => f.cliente).Include(f => f.proveedor);
            return View(foto.ToList());
        }

        // GET: foto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foto foto = db.foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // GET: foto/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "nombre");
            ViewBag.id_cliente = new SelectList(db.cliente, "id", "login");
            ViewBag.id_proveedor = new SelectList(db.proveedor, "id", "nombre");
            return View();
        }

        // POST: foto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_cliente,id_proveedor,id_categoria,url_foto,fecha_insercion,descripcion")] foto foto)
        {
            if (ModelState.IsValid)
            {
                db.foto.Add(foto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.categoria, "id", "nombre", foto.id_categoria);
            ViewBag.id_cliente = new SelectList(db.cliente, "id", "login", foto.id_cliente);
            ViewBag.id_proveedor = new SelectList(db.proveedor, "id", "nombre", foto.id_proveedor);
            return View(foto);
        }

        // GET: foto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foto foto = db.foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "nombre", foto.id_categoria);
            ViewBag.id_cliente = new SelectList(db.cliente, "id", "login", foto.id_cliente);
            ViewBag.id_proveedor = new SelectList(db.proveedor, "id", "nombre", foto.id_proveedor);
            return View(foto);
        }

        // POST: foto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_cliente,id_proveedor,id_categoria,url_foto,fecha_insercion,descripcion")] foto foto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.categoria, "id", "nombre", foto.id_categoria);
            ViewBag.id_cliente = new SelectList(db.cliente, "id", "login", foto.id_cliente);
            ViewBag.id_proveedor = new SelectList(db.proveedor, "id", "nombre", foto.id_proveedor);
            return View(foto);
        }

        // GET: foto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foto foto = db.foto.Find(id);
            if (foto == null)
            {
                return HttpNotFound();
            }
            return View(foto);
        }

        // POST: foto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foto foto = db.foto.Find(id);
            db.foto.Remove(foto);
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
