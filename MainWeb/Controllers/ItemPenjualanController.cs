﻿using MainWeb.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainWeb.Controllers
{
    public class ItemPenjualanController : Controller
    {
        // GET: ItemPenjualan
        public ActionResult Index()
        {
            return View();
        }

        // GET: ItemPenjualan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemPenjualan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemPenjualan/Create
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

        // GET: ItemPenjualan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ItemPenjualan/Edit/5
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

        // GET: ItemPenjualan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemPenjualan/Delete/5
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