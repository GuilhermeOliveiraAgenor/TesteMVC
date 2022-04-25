using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MercadoMVC.Models;

namespace MercadoMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private MercadoEntities2 banco = new MercadoEntities2();

        // GET: Categorias
        public ActionResult Index()
        {
            return View(banco.Categoria.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = banco.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCategoria,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                banco.Categoria.Add(categoria);
                banco.SaveChanges();
                TempData["AlertMessage"] = "Categoria cadastrada com sucesso";//Mensagem na tela
                return RedirectToAction("Create");
            }

            return View(categoria);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = banco.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCategoria,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                banco.Entry(categoria).State = EntityState.Modified;
                banco.SaveChanges();
                TempData["AlertMessage"] = "Categoria alterada com sucesso";//mensagem
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = banco.Categoria.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = banco.Categoria.Find(id);
            banco.Categoria.Remove(categoria);
            banco.SaveChanges();
            TempData["AlertMessage"] = "Categoria deletada com sucesso";//mensagem
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                banco.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
