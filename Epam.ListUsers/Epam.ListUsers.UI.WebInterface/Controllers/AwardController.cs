using Epam.ListUsers.BLL.Logic;
using Epam.ListUsers.Entities;
using Epam.ListUsers.UI.WebInterface.Helpers;
using Epam.ListUsers.UI.WebInterface.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Epam.ListUsers.UI.WebInterface.Controllers
{
    public class AwardController : Controller
    {
        private UsersLogic _logic = new UsersLogic();
        private string PuthToDefaultImageForAwards = ConfigurationManager.AppSettings["PathForDefaultImageOfAwards"];
        
        // GET: Award
        [Authorize(Roles="admin")]
        public ActionResult Index()
        {
            var model = _logic.GetAllAwards().Select(a => Converters.ToAwardModel(a));
            return View(model);
        }

        // GET: Award/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(Guid id)
        {
            var award = _logic.GetAwardById(id);
            var model = Converters.ToAwardModel(award);
            model.Users = _logic.GetAllUsersWithAward(award).Select(u => u.Name).ToList();
            return View(model);
        }

        // GET: Award/Create
        [Authorize(Roles="admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Award/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(AwardModel model, HttpPostedFileBase uploadedFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    model.Id = Guid.NewGuid();
                    Award award = Converters.ToAwardForLogic(model);
                    _logic.AddAward(award);
                    if (uploadedFile != null)
                    {
                        _logic.SetImageOfAward(model.Id, uploadedFile);
                    }
                    
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
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Guid id)
        {

            Award award = _logic.GetAwardById(id);
            var model = Converters.ToAwardModel(award); 
            return View(model);
        }

        // POST: Award/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(AwardModel model, HttpPostedFileBase uploadedFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var award = Converters.ToAwardForLogic(model);
                    _logic.EditAward(award);
                    if (uploadedFile != null)
                    {
                        _logic.SetImageOfAward(model.Id, uploadedFile);
                    }
                    
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
        [Authorize(Roles = "admin")]
        public ActionResult Delete(Guid id)
        {
            var award = _logic.GetAwardById(id);
            _logic.RemoveAward(award);
            return RedirectToAction("Index");
        }

        public ActionResult Get(Guid? id)
        {
            if (id.HasValue)
            {
                return File(_logic.GetImageOfAward(id.Value), "image/jpeg");
            }
            else
            {
                var imageDefault = System.IO.File.ReadAllBytes(PuthToDefaultImageForAwards);
                return File(imageDefault, "image/jpeg");
            }
        }
    }
}
