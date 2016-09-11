using Epam.ListUsers.BLL.Logic;
using Epam.ListUsers.UI.WebInterface.Helpers;
using Epam.ListUsers.UI.WebInterface.Models;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace Epam.ListUsers.UI.WebInterface.Controllers
{
    public class UserController : Controller
    {
        private UsersLogic _logic = new UsersLogic();
        private string PuthToDefaultImageForUsers = ConfigurationManager.AppSettings["PathForDefaultImageOfUsers"];

        // GET: User
        public ActionResult Index()
        {
            var model = _logic.GetAllUsers().Select(u => Converters.ToUserModelForDetails(u));
            return View(model);
        }

        // GET: User/Details/5
        [Authorize(Roles = "user")]    
        public ActionResult Details(Guid id)
        {
            var model = Converters.ToUserModelForDetails(_logic.GetUserById(id));
            return View(model);
        }

        // GET: User/Create
        [Authorize(Roles="admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(UserModelForCreate model, HttpPostedFileBase uploadedFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    model.Id = Guid.NewGuid();
                    User user = Converters.ToUserForLogic(model);
                    _logic.AddUser(user);
                    if (uploadedFile != null)
                    {
                        _logic.SetImageOfUser(model.Id, uploadedFile);
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

        // GET: User/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Guid id)
        {
            User user = _logic.GetUserById(id);
            var model = Converters.ToUserModelForEdit(user);
            
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(UserModelForEdit model, HttpPostedFileBase uploadedFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var user = Converters.ToUserForLogic(model);
                    _logic.EditUser(user);
                    if (uploadedFile != null)
                    {
                        _logic.EditImageOfUser(model.Id, uploadedFile);
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

        [Authorize(Roles = "admin")]
        public ActionResult DetailsAward(Guid idUser, Guid idAward)
        {
            var award = _logic.GetAwardById(idAward);
            var user = _logic.GetUserById(idUser);
            var model = Converters.ToAwardModelForDetails(award, user);
            return View(model);
        }

         //GET: User/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult ReAward(Guid idUser, Guid idAward)
        {
            var award = _logic.GetAwardById(idAward);
            var user = _logic.GetUserById(idUser);
            _logic.ReAward(user, award);
            return RedirectToAction("Edit", new { id = idUser });
        }

        // GET: User/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(Guid id)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    // TODO: Add delete logic here
                    var user = _logic.GetUserById(id);
                    _logic.RemoveUser(user);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
        
        [Authorize(Roles = "admin")]
        public ActionResult ToAward(Guid idUser)
        {
            var model = new AwardsModelForToAward();
            model.IdUser = idUser;
            model.Awards = _logic.GetAllAwards().Select(a => Converters.ToAwardModel(a)).ToList();
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult ToAwardThisUser(Guid idUser, Guid idAward)
        {
            if (ModelState.IsValid)
            {
                var user = _logic.GetUserById(idUser);
                var award = _logic.GetAwardById(idAward);
                _logic.ToAward(user, award);
            }
            else
            {
                return View();
            }
            return RedirectToAction("Edit", new { id = idUser });
        }

        public ActionResult Get(Guid? id)
        {
            if (id.HasValue)
	        {
                
                return File(_logic.GetImageOfUser(id.Value), "image/jpeg");
	        }
            else
            {
                var imageDefault = System.IO.File.ReadAllBytes(PuthToDefaultImageForUsers);
                return File(imageDefault, "image/jpeg");
            }
        }
    }
}
