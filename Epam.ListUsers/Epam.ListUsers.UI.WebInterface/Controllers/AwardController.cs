using Epam.ListUsers.BLL.Logic;
using Epam.ListUsers.Entities;
using Epam.ListUsers.UI.WebInterface.Helpers;
using Epam.ListUsers.UI.WebInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Epam.ListUsers.UI.WebInterface.Controllers
{
    public class AwardController : Controller
    {
        private UsersLogic _logic = new UsersLogic();
        
        // GET: Award
        public ActionResult Index()
        {
            var model = _logic.GetAllAwards().Select(a => Converters.ToAwardModel(a));
            return View(model);
        }

        // GET: Award/Details/5
        public ActionResult Details(Guid id)
        {
            var award = _logic.GetAwardById(id);
            var model = Converters.ToAwardModel(award);
            model.Users = _logic.GetAllUsersWithAward(award).Select(u => u.Name).ToList();
            return View(model);
        }

        // GET: Award/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Award/Create
        [HttpPost]
        public ActionResult Create(AwardModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    model.Id = Guid.NewGuid();
                    Award award = Converters.ToAwardForLogic(model);
                    _logic.AddAward(award);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        // GET: Award/Edit/5
        public ActionResult Edit(Guid id)
        {

            Award award = _logic.GetAwardById(id);
            var model = Converters.ToAwardModel(award); 
            return View(model);
        }

        // POST: Award/Edit/5
        [HttpPost]
        public ActionResult Edit(AwardModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var award = Converters.ToAwardForLogic(model);
                    _logic.EditAward(award);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        // GET: Award/Delete/5
        public ActionResult Delete(Guid id)
        {
            var award = _logic.GetAwardById(id);
            _logic.RemoveAward(award);
            return RedirectToAction("Index");
        }
    }
}
