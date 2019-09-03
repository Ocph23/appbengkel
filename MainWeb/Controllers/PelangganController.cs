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
    public class PelangganController : Controller
    {
        private PelangganContext pelangganContext = new PelangganContext();
        // GET: Pelanggan
        public ActionResult Index()
        {
            return View(pelangganContext.Get());
        }

        // GET: Pelanggan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pelanggan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pelanggan/Create
        [HttpPost]
        public ActionResult Create(Pelanggan item)
        {
            try
            {
                // TODO: Add insert logic here
                var result =pelangganContext.Insert(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pelanggan/Edit/5
        public ActionResult Edit(int id)
        {
            var item = pelangganContext.GetById(id);
            return View(item);
        }

        // POST: Pelanggan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pelanggan item)
        {
            try
            {
                // TODO: Add update logic here
                if (pelangganContext.Update(item, id) != null)
                    return RedirectToAction("Index");
                throw new SystemException("Data Tidak Tersimpan");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pelanggan/Delete/5
        public ActionResult Delete(int id)
        {
            return View(pelangganContext.GetById(id));
        }

        // POST: Pelanggan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                pelangganContext.Delete(id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}
