using MainWeb.DataAccess.Contexts;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class PenjualanController : Controller
    {
        private PenjualanContext penjualanContext = new PenjualanContext();
        // GET: Penjualan
        public ActionResult Index()
        {
            return View(penjualanContext.Get());
        }

        // GET: Penjualan/Details/5
        public ActionResult Details(int id)
        {
            var data = this.penjualanContext.GetById(id);
            return View();
        }

        // GET: Penjualan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Penjualan/Create
        [HttpPost]
        public ActionResult Create(Penjualan item)
        {
            try
            {
                if(penjualanContext.Insert(item)!=null)
                {
                    return RedirectToAction("Index");
                }
                else
                {

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Penjualan/Edit/5
        public ActionResult Edit(int id)
        {
            var data = this.penjualanContext.GetById(id);
            return View();
        }

        // POST: Penjualan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Penjualan collection)
        {
            try
            {
                collection.IdPenjualan = id;
                this.penjualanContext.Update(collection,id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Penjualan/Delete/5
        public ActionResult Delete(int id)
        {
            var data = this.penjualanContext.GetById(id);
            return RedirectToAction("Index");
        }

        // POST: Penjualan/Delete/5
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
