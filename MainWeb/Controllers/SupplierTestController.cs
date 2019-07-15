using MainWeb.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class SupplierTestController : Controller
    {

        SupplierContext context = new SupplierContext();
        // GET: SupplierTest
        public ActionResult Index()
        {
            return View(context.Get());
        }

        // GET: SupplierTest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierTest/Create
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

        // GET: SupplierTest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierTest/Edit/5
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

        // GET: SupplierTest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierTest/Delete/5
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
