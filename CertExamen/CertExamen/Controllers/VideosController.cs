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
    public class VideosController : Controller
    {
        //private Entities db = new Entities();

        // GET: Videos
        public ActionResult Index()
        {
            ViewBag.Title = "Listado de alumnos Videos";
            return View(VideoBLL.List());
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            ViewBag.id_cat = new SelectList(CategoriaBLL.List(), "id_cat", "nombre_cat");
            return View();
        }

        // POST: Videos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vid,titulo_vid,fecha_publicacion_vid,formato_vid,duracion_vid,id_cat")] Video video)
        {
            if (ModelState.IsValid)
            {
                VideoBLL.Create(video);
                return RedirectToAction("Index");
            }

            ViewBag.id_cat = new SelectList(CategoriaBLL.List(), "id_cat", "nombre_cat", video.id_cat);
            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cat = new SelectList(CategoriaBLL.List(), "id_cat", "nombre_cat", video.id_cat);
            return View(video);
        }

        // POST: Videos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vid,titulo_vid,fecha_publicacion_vid,formato_vid,duracion_vid,id_cat")] Video video)
        {
            if (ModelState.IsValid)
            {
                VideoBLL.Update(video);
            }
            ViewBag.id_cat = new SelectList(CategoriaBLL.List(), "id_cat", "nombre_cat", video.id_cat);
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoBLL.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
