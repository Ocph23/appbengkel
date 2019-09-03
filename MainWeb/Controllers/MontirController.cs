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
    public class MontirController : Controller
    {
        private MontirContext context = new MontirContext();
        // GET: Montir
        public ActionResult Index()
        {

            var result = context.Get();
            return View(result);
        }

        // GET: Montir/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = context.GetById(id);

                return View(result);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // GET: Montir/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Montir/Create
        [HttpPost]
        public ActionResult Create(Montir item)
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

        // GET: Montir/Edit/5
        public ActionResult Edit(int id)
        {
            var result = context.GetById(id);
            return View(result);
        }

        // POST: Montir/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Montir item)
        {
            try
            {
                if (context.Update(item,id) != null)
                    return RedirectToAction("Index");
                throw new SystemException("Data Tidak Tersimpan");
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // GET: Montir/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var result = context.GetById(id);
                return View(result);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // POST: Montir/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Montir collection)
        {
            try
            {
                if(context.Delete(id))
                {
                    return RedirectToAction("Index");
                }
                throw new SystemException("Data Tidak Terhapus");
            }
            catch(Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }


        [HttpGet]
        public ActionResult PrintUpah(int id, int bulan)
        {
            var result = context.GetById(id);
            ViewBag.Bulan = bulan;
            return View(result);
        }
    }
}
