using MainWeb.DataAccess.Contexts;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class PembelianController : Controller
    {
        private SupplierContext supplierContext = new SupplierContext();
        private PembelianContext context = new PembelianContext();

        // GET: Pembelian
        public ActionResult Index()
        {
            return View();
        }
        // GET: Pembelian/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pembelian/Create
        public ActionResult Create()
        {
            var data = from a in supplierContext.Get() select new SelectListItem { Value = a.IdSupplier.ToString(), Text = a.NamaSupplier};
            ViewBag.DataSupplier = data.ToList();
            return View();
        }

        // POST: Pembelian/Create
        [HttpPost]
        public ActionResult Create(Pembelian model)
        {
            try
            {
                var context = new PembelianContext();
                if(context.Insert(model)!=null)
                {
                    return RedirectToAction("Index");
                }
                throw new SystemException("Data Tidak Tersimpan");
            }
            catch(Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // GET: Pembelian/Edit/5
        public ActionResult Edit(int id)
        {
            var data = from a in supplierContext.Get() select new SelectListItem { Value = a.IdSupplier.ToString(), Text = a.NamaSupplier };
            ViewBag.DataSupplier = data.ToList();
            return View(new Pembelian{IdPembelian=id });

        }

        // POST: Pembelian/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
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
        public ActionResult Delete(int id, Pembelian value)
        {
            try
            {
               
                if(context.Delete(id))
                    return RedirectToAction("Index");
                throw new SystemException("Data Tidak Terhapus");
            }
            catch(Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}
