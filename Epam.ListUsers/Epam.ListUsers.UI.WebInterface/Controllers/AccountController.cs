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
    }
}