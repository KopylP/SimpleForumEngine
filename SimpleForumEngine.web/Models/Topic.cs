using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models
{
    public class Topic : Content
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool IsMessaging { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public ICollection<Message> Messages { get; set; }
        public Topic()
        {
            Messages = new List<Message>();
            Date = DateTime.Now;
        }
    }
}