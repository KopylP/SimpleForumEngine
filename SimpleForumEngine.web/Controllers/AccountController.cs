using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleForumEngine.web.Models;
using SimpleForumEngine.web.Models.Authentication;
using System.Web.Security;
using System.Text;

namespace SimpleForumEngine.web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                using (ForumContext db = new ForumContext())
                {
                    User user = db.Users.FirstOrDefault(n => n.Email == model.Email);

                    if(user == null)
                    {
                        ModelState.AddModelError("", "User not found, please, check your data!");
                    }
                    else
                    {
                        if (Hasher.CompareStrings(model.Password, user.Password))
                        {
                            FormsAuthentication.SetAuthCookie(model.Email, true);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                            ModelState.AddModelError("", "Password is incorect");
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationModel model)
        {
            User user = null;
            if(ModelState.IsValid)
            {
                using (ForumContext db = new ForumContext())
                {
                    user = db.Users.FirstOrDefault(n => n.Email == model.Email);
                    if (user != null)
                    {
                        ModelState.AddModelError("", "User are already exist!");
                    }
                    else if(user == null)
                    {
                        var salt = Hasher.GenarateSalt();
                        var password = Hasher.SHA256(Hasher.ToByte(model.Password).ToArray(), salt);
                        string passwordStr = Hasher.getPasswordString(password, salt);
                        db.Users.Add(new User() { Name = model.Name, Password = passwordStr, Email = model.Email, RoleId = 3 });
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}