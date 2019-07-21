using MainWeb.DataAccess.Contexts;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class BarangController : Controller
    {
        private BarangContext barangContext = new BarangContext();
        // GET: Barang
        public ActionResult Index()
        {
            return View(barangContext.Get());
        }

        // GET: Barang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Barang/Create
        public ActionResult Create()
        {
            var data= from a in barangContext.GetKategories() select new SelectListItem { Value=a.IdKategori.ToString(), Text=a.NamaKategori };
            ViewBag.DataKategori = data;
            return View();
        }

        // POST: Barang/Create
        [HttpPost]
        public ActionResult Create(Barang data)
        {
            try
            {
                barangContext.Insert(data);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Barang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Barang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Barang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Barang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
