using MainWeb.DataAccess.Contexts;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {

        KategoriContext context = new KategoriContext();
        // GET: Kategori
        public ActionResult Index()
        {
            return View(context.Get());
        }

        // GET: Kategori/Details/5
        public ActionResult Details(int id)
        {
            var model = context.GetById(id);
            return View(model);
        }

        // GET: Kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategori/Create
        [HttpPost]
        public ActionResult Create(Kategori item)
        {
            try
            {
               if(context.Insert(item)!=null)
                    return RedirectToAction("Index");
                throw new SystemException("Data Tidak Tersimpan");
            }
            catch(Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int id)
        {
            var model = context.GetById(id);
            return View(model);
        }

        // POST: Kategori/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Kategori item)
        {
            try
            {
                if (context.Update(item, id) == null)
                    throw new SystemException("Data Tidak Tersimpan");
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // GET: Kategori/Delete/5
        public ActionResult Delete(int id)
        {
            var model = context.GetById(id);
            return View(model);
        }

        // POST: Kategori/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Kategori item)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View("Error", ex );
            }
        }
    }
}
