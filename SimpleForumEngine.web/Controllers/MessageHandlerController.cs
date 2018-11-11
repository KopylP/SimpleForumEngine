using SimpleForumEngine.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using ImageResizer;
namespace SimpleForumEngine.web.Controllers
{
    public class MessageHandlerController : Controller
    {
        ForumContext db = new ForumContext();
        [HttpPost]
        public ActionResult SendMessage(MessageAuthor message)
        {
            //Доделать проверку
            Message m = new Message() { TopicId = message.TopicId, Content = message.Content };
            m.UserId = db.Users.FirstOrDefault(n => n.Email == message.Author).Id;
            m.Date = DateTime.Now;
            db.Messages.Add(m);
            db.SaveChanges();
            m = db.Messages.Find(m.Id);
            if (message.Files.Count() != 0)
            {
                foreach(var photo in message.Photos)
                {
                    if (photo == null)
                        continue;
                    string Extension = Path.GetExtension(photo.FileName);
                    string Name = (Directory.GetFiles(Server.MapPath("~/Files/Photo")).Length/2).ToString();
                    photo.InputStream.Seek(0, SeekOrigin.Begin);
                    ImageBuilder.Current.Build( new ImageJob(
                            photo.InputStream,
                            Server.MapPath("~/Files/Photo/") + Name + "_small" + Extension,
                            new Instructions("maxwidth=100&maxheight=100"),
                            false,
                            false
                        )
                        );
                    photo.InputStream.Seek(0, SeekOrigin.Begin);
                    photo.SaveAs(Server.MapPath("~/Files/Photo/") + Name + Extension);
                    MessageFile mf = new MessageFile() { Path = Name + Extension, MessageId = m.Id, IsPhoto = true, OriginalName = Name + Extension };
                    mf.Name = Name;
                    mf.Extension = Extension;
                    db.MessageFiles.Add(mf);
                    db.SaveChanges();
                }
                foreach(var file in message.Files)
                {
                    if (file == null)
                        continue;
                    string Extension = Path.GetExtension(file.FileName);
                    string Name = Directory.GetFiles(Server.MapPath("~/Files/UserFiles/")).Length.ToString();
                    file.SaveAs(Server.MapPath("~/Files/UserFiles/") + Name + Extension);
                    MessageFile mf = new MessageFile() { Path = Name + Extension, MessageId = m.Id, IsPhoto = false, OriginalName = Name + Extension };
                    mf.Name = Name;
                    mf.Extension = Extension;
                    db.MessageFiles.Add(mf);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Topic", "Home", new { id = message.TopicId });
        }
        [HttpPost]
        public ActionResult DeleteMessage(int messageId)
        {
            //Доробити перевірку
            var message = db.Messages.Include(n => n.MessageFiles).FirstOrDefault(n => n.Id == messageId);
            if (message != null)
            {
                int count = message.MessageFiles.Count;
                while (count > 0)
                {
                    db.Entry(message.MessageFiles.First()).State = EntityState.Deleted;
                    count = message.MessageFiles.Count;
                }
                db.SaveChanges();
                db.Entry(message).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("Topic", "Home", new { id = message.TopicId });
        }
    }
}