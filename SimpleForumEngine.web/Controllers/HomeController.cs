using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleForumEngine.web.Models;
using System.Data.Entity;
namespace SimpleForumEngine.web.Controllers
{
    public class HomeController : Controller
    {
        ForumContext db = new ForumContext();
        public ActionResult Index()
        {
            List<Folder> contents = new List<Models.Folder>();
            contents = db.Folders.Include(n => n.Children).Include(n => n.Topics).Where(n => n.ParentId == null).ToList();
            return View(contents);
        }
        [HttpPost]
        public ActionResult CreateFolder(Folder folder, string CanCreateTopicStr)
        {
            folder.CanCreateTopic = CanCreateTopicStr == "true" ? true : false;
            db.Folders.Add(folder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Folder(int Id)
        {
            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    ViewBag.UserId = db.Users.FirstOrDefault(n => User.Identity.Name == n.Email).Id;
                }
                catch (Exception){}
            }
            Folder folder = db.Folders.Include(n => n.Children).Include(n => n.Topics).FirstOrDefault(n => n.Id == Id);
            if (folder != null)
                return View(folder);
            else
                return HttpNotFound();

        }
  
        public ActionResult Topic(int id)
        {
            Topic topic = null;
            topic = db.Topics.Include(n => n.Folder).FirstOrDefault(n => n.Id == id);
            if (topic == null)
                return HttpNotFound();
            ViewBag.Messages = db.Messages.Include(n => n.User).Include(n => n.MessageFiles).Where(n => n.TopicId == id).ToList();
            return View(topic);
        }
    }
}