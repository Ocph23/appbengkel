using MainWeb.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class PembelianController : Controller
    {
        private PembelianContext pembelianContext = new PembelianContext();
        // GET: Pembelian
        public ActionResult Index()
        {
            return View(pembelianContext.Get());
        }

        // GET: Pembelian/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pembelian/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pembelian/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pembelian/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pembelian/Edit/5
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

        // GET: Pembelian/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pembelian/Delete/5
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
