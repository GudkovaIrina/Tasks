﻿using Epam.ListUsers.BLL.Logic;
using Epam.ListUsers.UI.WebInterface.Helpers;
using Epam.ListUsers.UI.WebInterface.Models;
using Epam.ListUsers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.ListUsers.UI.WebInterface.Controllers
{
    public class UserController : Controller
    {
        private UsersLogic _logic = new UsersLogic();

        // GET: User
        public ActionResult Index(Guid? Id)
        {
            var model = _logic.GetAllUsers().Select(u => Converters.ToUserModelForDetails(u));

            if (Id.HasValue)
            {
                ViewBag.ConfirmedUser = Converters.ToUserModelForDetails(_logic.GetUserById(Id.Value));
            }

            return View(model);
        }

        // GET: User/Details/5
        public ActionResult Details(Guid id)
        {
            var model = Converters.ToUserModelForDetails(_logic.GetUserById(id));
            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModelForCreate model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    model.Id = Guid.NewGuid();
                    User user = Converters.ToUserForLogic(model);
                    _logic.AddUser(user);
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
        public ActionResult Edit(Guid id, Guid? idAward)
        {
            User user = _logic.GetUserById(id);
            var model = Converters.ToUserModelForEdit(user);
            if (idAward.HasValue)
            {
                ViewBag.ConfirmedAward = Converters.ToAwardModelForDetails(_logic.GetAwardById(idAward.Value),
                                                                           _logic.GetUserById(id));
            }

            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserModelForEdit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    var user = Converters.ToUserForLogic(model);
                    _logic.EditUser(user);
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

        public ActionResult DetailsAward(Guid idUser, Guid idAward)
        {
            var award = _logic.GetAwardById(idAward);
            var user = _logic.GetUserById(idUser);
            var model = Converters.ToAwardModelForDetails(award, user);
            return View(model);
        }

         //GET: User/Delete/5
        public ActionResult ReAward(Guid idUser, Guid idAward)
        {
            var award = _logic.GetAwardById(idAward);
            var user = _logic.GetUserById(idUser);
            _logic.ReAward(user, award);
            return RedirectToAction("Edit", new { id = idUser });
        }

        // GET: User/Delete/5
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

        public ActionResult ToAward(Guid idUser)
        {
            var model = new AwardsModelForToAward();
            model.IdUser = idUser;
            model.Awards = _logic.GetAllAwards().Select(a => Converters.ToAwardModel(a)).ToList();
            return View(model);
        }

        public ActionResult ToAwardThisAward(Guid idUser, Guid idAward)
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
    }
}
