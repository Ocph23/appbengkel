using MainWeb.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class MontirController : Controller
    {
        private MontirContext montirContext = new MontirContext();
        // GET: Montir
        public ActionResult Index()
        {
            return View(montirContext.Get());
        }

        // GET: Montir/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Montir/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Montir/Create
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

        // GET: Montir/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Montir/Edit/5
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

        // GET: Montir/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Montir/Delete/5
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
