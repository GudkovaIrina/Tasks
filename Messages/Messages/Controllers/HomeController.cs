using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Messages.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = Messages.Models.Message.GetAll();
            return View(model);
        }

        // GET: Home/Details/5
        public ActionResult Details(Guid id)
        {
            var model = Messages.Models.Message.GetById(id);
            return View(model);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Messages.Models.Message model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    Messages.Models.Message.Create(model);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(model);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = Messages.Models.Message.GetById(id);
            return View(model);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Messages.Models.Message model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    Messages.Models.Message.Edit(model);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = Messages.Models.Message.GetById(id);
            return View(model);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(Messages.Models.Message model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add delete logic here
                    Messages.Models.Message.Remove(model.Id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
