using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUEjercicio;
using BEUEjercicio.Transactions;

namespace CertExamen.Controllers
{
    public class LibrosController : Controller
    {
        //private Entities db = new Entities();

        // GET: Libros
        public ActionResult Index()
        {
            
            return View(LibroBLL.List());
        }

        // GET: Libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.id_cat = new SelectList(CategoriaBLL.List(), "id_cat", "nombre_cat");
            return View();
        }

        // POST: Libros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_lib,titulo_lib,autor_lib,fecha_publicacion_lib,num_lib,id_cat")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                LibroBLL.Create(libro);
                return RedirectToAction("Index");
            }

            ViewBag.id_cat = new SelectList(CategoriaBLL.List(), "id_cat", "nombre_cat", libro.id_cat);
            return View(libro);
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cat = new SelectList(CategoriaBLL.List(), "id_cat", "nombre_cat", libro.id_cat);
            return View(libro);
        }

        // POST: Libros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_lib,titulo_lib,autor_lib,fecha_publicacion_lib,num_lib,id_cat")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                LibroBLL.Update(libro);
                return RedirectToAction("Index");
            }
            ViewBag.id_cat = new SelectList(CategoriaBLL.List(), "id_cat", "nombre_cat", libro.id_cat);
            return View(libro);
        }

        // GET: Libros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibroBLL.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
