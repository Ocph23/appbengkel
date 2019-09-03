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
    public class BarangController : Controller
    {
        private BarangContext barangContext = new BarangContext();
        // GET: Barang
        public ActionResult Index()
        {
            IEnumerable<Barang> result = barangContext.Get();
            return View(result);
        }

        public JsonResult GetBarang()
        {
            var result= Json( barangContext.Get(), JsonRequestBehavior.AllowGet);
            return result;
        }

        // GET: Barang/Details/5
        public ActionResult Details(int id)
        {
            var data = barangContext.GetById(id);
            return View(data);
        }

        // GET: Barang/Create
        public ActionResult Create()
        {
            var data= from a in barangContext.GetKategories() select new SelectListItem { Value=a.IdKategori.ToString(), Text=a.NamaKategori };
            ViewBag.DataKategori = data.ToList();
            return View();
        }

        // POST: Barang/Create
        [HttpPost]
        public ActionResult Create(Barang data)
        {
            try
            {
                if (barangContext.Insert(data) != null)
                    return RedirectToAction("Index");
                throw new SystemException("Data Tidak Tersimpan");
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // GET: Barang/Edit/5
        public ActionResult Edit(int id)
        {

            var barang = barangContext.GetById(id);
            if (barang != null)
            {
                var data = from a in barangContext.GetKategories() select new SelectListItem { Value = a.IdKategori.ToString(), Text = a.NamaKategori };
                ViewBag.DataKategori = data;
                return View(barang);
            }

            throw new SystemException("Data Tidak Ditemukan");
            
        }

        // POST: Barang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Barang item)
        {
            try
            {
                if(barangContext.Update(item,id)!=null)
                     return RedirectToAction("Index");
                else
                    throw new SystemException("Data Tidak Ditemukan");
            }
            catch(Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // GET: Barang/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var barang = barangContext.Delete(id);
                if (barang)
                {
                    return RedirectToAction("Index");
                }

                throw new SystemException("Data Tidak Ditemukan");
            }
            catch (Exception  ex)
            {
                throw new SystemException(ex.Message);
            }
        }

       
    }
}
