using SimpleForumEngine.web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SimpleForumEngine.web.Controllers
{
    public class AdminPanelController : Controller
    {
        // GET: AdminPanel
        ForumContext db = new ForumContext();
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UserList()
        {
            ViewBag.Roles = await db.Roles.ToListAsync();
            IEnumerable<User> users = await db.Users.Include(n => n.Role).ToListAsync();
            return View(users);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public JsonResult Search(string msg)
        {
            var users = db.Users.Where(n => n.Name.Contains(msg) || n.Email.Contains(msg)).Select(n => new {name =  n.Name, email =  n.Email, id = n.Id }).ToList();
            return Json(users);
        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Common()
        {
            CommonInformation info = null;
            try
            {
                info = db.CommonInformations.First();
            }
            catch (InvalidOperationException) { }
            if(info == null)
            {
                info = new CommonInformation() { Discription = "Discription", Name = "Name"};
                db.CommonInformations.Add(info);
                db.SaveChanges();
            }
            return View(info);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Common(CommonInformation info)
        {
            db.Entry(info).State = EntityState.Modified;
            db.SaveChanges();
            return View(info);
        }
        [Authorize(Roles = "admin")]
        public ActionResult AdminToolsPartial()
        {
            return PartialView();
        }
        public ActionResult EditUser(string action, string role, int userId)
        {
            User user = db.Users.Find(userId);
            if (user == null)
                return RedirectToAction("UserList");
            if (action == "delete")
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            else if(action == "edit")
            {
                if(role != "select option")
                {
                    Role userRole = db.Roles.FirstOrDefault(n => n.Name == role);
                    if (userRole != null)
                    {
                        user.RoleId = userRole.Id;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("UserList");
        }
    }
}
    