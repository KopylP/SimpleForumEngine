using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForumEngine.web.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public ICollection<MessageFile> MessageFiles { get; set; }
        public Message()
        {
            MessageFiles = new List<MessageFile>();
            Date = DateTime.Now;
        }
    }
}