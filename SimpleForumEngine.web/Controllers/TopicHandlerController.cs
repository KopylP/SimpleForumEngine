using SimpleForumEngine.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace SimpleForumEngine.web.Controllers
{
    public class TopicHandlerController : Controller
    {
        ForumContext db = new ForumContext();
        [HttpPost]
        public ActionResult CreateTopic(Topic topic, string IsMessagingStr)
        {
            topic.IsMessaging = IsMessagingStr == "true" ? true : false;
            topic.Date = DateTime.Now;
            db.Topics.Add(topic);
            db.SaveChanges();
            var topicMy = db.Topics.ToList().FirstOrDefault(n => n.Date == topic.Date);
            return RedirectToAction("Topic", "Home", new { id = topicMy.Id });
        }
        public ActionResult EditTopic(Topic topic, string IsMessagingStr)
        {
            topic.IsMessaging = IsMessagingStr == "true" ? true : false;
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Topic", "Home", new { id = topic.Id});
        }
    }
}