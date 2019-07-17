using MainWeb.DataAccess.Contexts;
using MainWeb.Models;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class SupplierController : Controller
    {
        private SupplierContext suplierContext = new SupplierContext();
        // GET: Supplier
        public ActionResult Index()
        {

            return View(suplierContext.Get());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            var data = this.suplierContext.GetById(id);
            return View(data);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(Supplier item)
        {
            try
            {
                
                if(suplierContext.Insert(item)!=null)
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

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            var data = this.suplierContext.GetById(id);
            return View(data);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Supplier collection)
        {
            try
            {
                collection.IdSupplier = id;
                this.suplierContext.Update(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            var data = this.suplierContext.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Supplier collection)
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
