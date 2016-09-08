using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.ListUsers.UI.WebInterface.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Models.LoginModel.TryToLogin(model))
                {
                    if (returnUrl == null)
                    {
                        return Redirect("~");
                    }
                    return Redirect(returnUrl);
                }
                else 
                {
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.ErrorMessage = "Не правильно введены имя пользователя или пароль. Попытайтесь еще раз!";
                    return View(model);
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            Models.LoginModel.Logout();
            return Redirect("~");
        }

        public ActionResult ToRegister(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult ToRegister(Models.RegisterModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Models.RegisterModel.TryToRegister(model))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.Message = "Такой пользователь уже есть. Введите другое имя пользователя!";
                    return View(model);
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult UserInfo()
        {
            return PartialView();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Administration()
        {
            var model = Models.RolesOfUserModel.GetAll();
            ViewBag.Roles = new Models.MyRoleProvider().GetAllRoles().ToList();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Administration(string userName, string roleForAdd)
        {
            Models.RolesOfUserModel.EditRolesOfUser(userName, roleForAdd, Models.RolesOfUserModel.AddRoleToUser);
            return RedirectToAction("Administration");
        }
        
        [Authorize(Roles = "admin")]
        public ActionResult WithdrawalRoles(string userName, string role)
        {
            Models.RolesOfUserModel.EditRolesOfUser(userName, role,Models.RolesOfUserModel.RemoveRoleAtUser);
            return RedirectToAction("Administration");
        }
    }
}